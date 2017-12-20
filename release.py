#!/usr/bin/env python3
import sys
import os
import shutil
#import zipfile

#copied from KivyGlops (etc/kivyglopsdelta.py)
class SyncOptions:
    def __init__(self):
        self.scan_dot_folders_enable = True
        self.mode = "force"
        self.copied_count = 0
        self.removed_count = 0
        self.leave_out_dot_git_enable = True
        self.verbose_enable = False

#copied from KivyGlops (etc/kivyglopsdelta.py)
def sync_recursively(master_path, target_path, options):
    if os.path.isdir(master_path):
        for master_name in os.listdir(master_path):
            my_path = os.path.join(master_path, master_name)
            try_path = os.path.join(target_path, master_name)
            if os.path.isfile(my_path):
                master_mtime = os.path.getmtime(my_path)
                try_mtime = None
                if os.path.isfile(try_path):
                    try_mtime = os.path.getmtime(try_path)
                if ((options.mode=="force") and ((try_mtime==None)or(try_mtime!=master_mtime)))  or \
                   ((options.mode=="update") and ((try_mtime==None)or(try_mtime<master_mtime))):
                    if (not options.leave_out_dot_git_enable) or (master_name != ".gitignore"):
                        if try_mtime is not None:
                            if try_mtime>=master_mtime:
                                if options.verbose_enable:
                                    print('#override "'+try_path+'"')
                            else:
                                if options.verbose_enable:
                                    print('#update "'+try_path+'"')
                        else:
                            if options.verbose_enable:
                                print('#add "'+try_path+'"')
                        if not os.path.isdir(target_path):
                            os.makedirs(target_path)
                        shutil.copy2(my_path, try_path)
                        options.copied_count += 1
                if options.mode=="clear":
                    if try_mtime is not None:
                        if options.verbose_enable:
                            print('rm "'+try_path+'"')
                        os.remove(try_path)
                        options.removed_count += 1
            else:
                if options.scan_dot_folders_enable or (master_name[:1]!="."):
                    if (options.mode=="clear") or not (options.leave_out_dot_git_enable and (master_name==".git")):
                        sync_recursively(my_path, try_path, options)
            if os.path.isdir(try_path):
                if not os.listdir(try_path):  # if empty
                    os.rmdir(try_path)
    else:
        print("ERROR: non-directory sent to sync_recursively: '"+master_path+"'")



from os.path import dirname, abspath
self_path = os.path.dirname(os.path.abspath(__file__))
projects_path = os.path.dirname(self_path)

version_string = "prerelease"
release_notes_path = "README.md"
ins = open(release_notes_path, 'r')
line = True
line_number = 1
while line:
    line = ins.readline()
    if line:
        release_marker = " Released "
        release_marker_i = line.find(release_marker)
        if release_marker_i > -1:
            release_i = release_marker_i + len(release_marker)
            release_part = line[release_i:]
            chunks = release_part.split(" ")
            version_string = chunks[0].strip()
            print(release_notes_path+" ("+str(line_number)+","+str(release_i+1)+"): Found ' Release ' and version_string " + version_string)
            break
        line_number += 1
        
ins.close()


options = SyncOptions()
project_name = os.path.basename(self_path)
print("Project '"+project_name+"': Syncing self from '" + self_path + "'")
#bin_path = os.path.join(self_path, "bin")
#if not os.path.isdir(bin_path):
#    os.makedirs(bin_path)
release_dir_name = project_name + "-" + version_string + "-release"
release_path = os.path.join(projects_path, release_dir_name)
if not os.path.isdir(release_path):
    os.makedirs(release_path)
sync_recursively(self_path,release_path,options)

print("sync_recursively ("+options.mode+") result:")
print("  copied: "+str(options.copied_count))
print("  removed: "+str(options.removed_count))

#NOTE: .git is not copied by sync_recursively above as per default options

non_release_names = [".git"]  # "etc"
for non_release_name in non_release_names:
    non_release_path = os.path.join(release_path, non_release_name)
    if os.path.isdir(non_release_path):
        shutil.rmtree(non_release_path, ignore_errors=False)
        print("removed non-release data in destination's copy of " + non_release_name)

release_zip_name_noext = release_dir_name  # .zip is appended automatically by shutil.make_archive
release_zip_path_noext = os.path.join(projects_path, release_zip_name_noext)
release_zip_name = release_zip_name_noext + ".zip"
release_zip_path = os.path.join(projects_path, release_zip_name)
if os.path.isfile(release_zip_path):
    os.remove(release_zip_path)
    print("removed old '" + release_zip_name + "'")
shutil.make_archive(release_zip_path_noext, 'zip', release_path)
if os.path.isfile(release_zip_path):
    print("successfully created '" + release_zip_path + "'")
    shutil.rmtree(release_path, ignore_errors=False)
    print("removed temporary folder '" + release_path + "'")
else:
    print("ERROR: shutil failed to create '" + release_zip_path + "'")


