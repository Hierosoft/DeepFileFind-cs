* deprecated since replaced by get_is_content_searchable
```

            try {
                //CanRead
                //by Chibueze Opata on https://stackoverflow.com/questions/11709862/check-if-directory-is-accessible-in-c answered Jul 29 '12 at 14:52  edited Jul 29 '12 at 16:53
                var readAllow = false;
                var readDeny = false;
                var accessControlList = Directory.GetAccessControl (path);
                if (accessControlList == null)
                    return false;
                var accessRules = accessControlList.GetAccessRules (true, true, typeof (System.Security.Principal.SecurityIdentifier));
                if (accessRules == null)
                    return false;

                foreach (FileSystemAccessRule rule in accessRules) {
                    if ((FileSystemRights.Read & rule.FileSystemRights) != FileSystemRights.Read) continue;

                    if (rule.AccessControlType == AccessControlType.Allow)
                        readAllow = true;
                    else if (rule.AccessControlType == AccessControlType.Deny)
                        readDeny = true;
                }

                result = readAllow && !readDeny;
            }
            catch (System.PlatformNotSupportedException) {  //since above is not supported on linux
                                                            //see https://stackoverflow.com/questions/12772930/test-file-permissions-on-mono
                                                            //var ufi = new UnixFileInfo(path);
                                                            //ufi.CanAccess (AccessModes.F_OK); // is a file/directory
                                                            //ufi.CanAccess (AccessModes.R_OK); // accessible for reading
                                                            //ufi.CanAccess (AccessModes.W_OK); // accessible for writing
                                                            //ufi.CanAccess (AccessModes.X_OK); // accessible for executing
            }
            ```