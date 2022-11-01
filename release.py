#!/usr/bin/env python3
from __future__ import print_function
import sys
import os
import shutil
from subprocess import (
    PIPE,
    Popen,
)
# import zipfile

if sys.version_info.major < 3:
    input = raw_input


# copied from KivyGlops (etc/kivyglopsdelta.py)
class SyncOptions:
    def __init__(self):
        self.scan_dot_folders_enable = True
        self.mode = "force"
        self.copied_count = 0
        self.removed_count = 0
        self.leave_out_dot_git_enable = True
        self.verbose_enable = False


# copied from KivyGlops (etc/kivyglopsdelta.py)
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
                if (((options.mode == "force")
                        and ((try_mtime is None)
                             or (try_mtime != master_mtime)))
                        or ((options.mode == "update")
                            and ((try_mtime is None)
                                 or (try_mtime < master_mtime)))):
                    if ((not options.leave_out_dot_git_enable)
                            or (master_name != ".gitignore")):
                        if try_mtime is not None:
                            if try_mtime >= master_mtime:
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
                if options.mode == "clear":
                    if try_mtime is not None:
                        if options.verbose_enable:
                            print('rm "'+try_path+'"')
                        os.remove(try_path)
                        options.removed_count += 1
            else:
                if options.scan_dot_folders_enable or (master_name[:1] != "."):
                    if ((options.mode == "clear")
                            or not (options.leave_out_dot_git_enable
                                    and (master_name == ".git"))):
                        sync_recursively(my_path, try_path, options)
            if os.path.isdir(try_path):
                if not os.listdir(try_path):  # if empty
                    os.rmdir(try_path)
    else:
        print('ERROR: non-directory sent to sync_recursively: "{}"'
              ''.format(master_path))


def get_version(cmd_parts):
    print("* Using Python {}.{}"
          "".format(sys.version_info.major, sys.version_info.minor))
    print('* Running "'+' '.join(cmd_parts)+'"')
    # See
    # <https://stackoverflow.com/questions/16768290/understanding-popen-communicate>.
    result = None
    p = Popen(cmd_parts, stdin=PIPE, stdout=PIPE, bufsize=1)
    result = p.stdout.readline()
    # See also os.device_encoding(file_descriptor)
    for i in range(10):
        pass
        # print >>p.stdin, i # write input
        # p.stdin.flush() # not necessary in this case
        # print p.stdout.readline(), # read output

    if sys.version_info.major >= 3:
        out, err = p.communicate("n\n".encode(sys.stdout.encoding))
    else:
        out, err = p.communicate("n\n")
    # ^ Signal the child to exit, read the rest of the output,
    #   wait for the child to exit.
    if result is None:
        return None
    # Always strip it, because it usually ends with "\n":
    elif sys.version_info.major < 3:
        return result.strip()
    return result.decode(sys.stdout.encoding).strip()


def main():
    self_path = os.path.dirname(os.path.abspath(__file__))
    projects_path = os.path.dirname(self_path)

    version_string = "prerelease"
    # release_notes_path = "README.md"

    release_marker = "## ["
    release_ender = "]"
    release_notes_path = "changelog.md"
    print('Looking for release number in "{}" ("{}" to "{}")'
          ''.format(release_notes_path, release_marker, release_ender))

    ins = open(release_notes_path, 'r')
    line = True
    line_number = 1
    while line:
        line = ins.readline()
        if line:
            # release_marker = " Released "
            release_marker_i = line.find(release_marker)
            if release_marker_i > -1:
                release_i = release_marker_i + len(release_marker)
                release_part = line[release_i:]
                # chunks = release_part.split(" ")
                chunks = release_part.split(release_ender)
                version_string = chunks[0].strip()
                print("{} ({},{}): Found ' Release ' and version_string {}"
                      "".format(release_notes_path, line_number,
                                release_i+1, version_string))
                break
            line_number += 1

    ins.close()

    options = SyncOptions()
    project_name = os.path.basename(self_path)
    print("Project '"+project_name+"': Syncing self from '" + self_path + "'")
    # bin_path = os.path.join(self_path, "bin")
    # if not os.path.isdir(bin_path):
    #     os.makedirs(bin_path)
    release_dir_name = project_name + "-" + version_string + "-windows-x64"
    release_path = os.path.join(projects_path, release_dir_name)
    if not os.path.isdir(release_path):
        os.makedirs(release_path)
    sync_recursively(self_path, release_path, options)

    self_exe = os.path.join(self_path, "bin", "WindowsRelease",
                            "DeepFileFind.exe")
    release_exe = os.path.join(release_path, "bin", "WindowsRelease",
                               "DeepFileFind.exe")

    if not os.path.isfile(self_exe):
        print('Error: "{}" is missing.'.format(self_exe))
        sys.exit(1)

    self_time = os.path.getmtime(self_exe)
    release_time = os.path.getmtime(release_exe)

    print("sync_recursively ("+options.mode+") result:")
    print("  copied: "+str(options.copied_count))
    print("  removed: "+str(options.removed_count))

    got_version = get_version([
        os.path.join(release_path, "bin", "WindowsRelease", "DeepFileFind.exe"),
        "--version",
    ])

    # NOTE: .git is not copied by sync_recursively above as per default options

    non_release_names = [".git"]  # "etc"
    for non_release_name in non_release_names:
        non_release_path = os.path.join(release_path, non_release_name)
        if os.path.isdir(non_release_path):
            shutil.rmtree(non_release_path, ignore_errors=False)
            print("removed non-release data in destination's copy of "
                  + non_release_name)

    release_zip_name_noext = release_dir_name
    # ^ .zip is appended automatically by shutil.make_archive
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
        sys.exit(1)
    print()

    if self_time != release_time:
        print("Match executable dates after sync...no")
        print("Error: file dates don't match.")
        print('self_time={} ("{}")'.format(self_time, self_exe))
        print('release_time={} ("{}")'.format(release_time, release_exe))
        sys.exit(1)
    else:
        print("Match executable dates after sync...yes")

    if version_string != got_version:
        print('version_string="{}"'.format(version_string))
        print('mainform.Text version="{}"'.format(got_version))
        print("Error: Set the version in the title bar"
              " (mainform.Text) to {} or change {}"
              " then re-run this release script."
              "".format(version_string, release_notes_path))
        sys.exit(1)
    else:
        print("Match versions...yes"
              " (The program reported that its title bar is version {})"
              "".format(got_version))

    print('"{}" is ready.'.format(release_zip_path))


if __name__ == "__main__":
    code = main()
    input("Press enter to exit...")
    sys.exit(code)
