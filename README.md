# DeepFileFind
The goal of this project is to create the most satisfying search program in the world. DeepFileFind...

* Has features you need
* Isn't annoying
* Is GPL (free as in freedom, forever--redistribute modify according to the terms as you wish). Full source code of original project is at <https://github.com/expertmm/DeepFileFind/releases>.

--in other words, it's a program like nothing before it.

## Install

### Windows
- Download a DeepFileFind windows zip from [Releases](https://github.com/poikilos/DeepFileFind-cs/releases).
- Open/Run
- Drag DeepFileFind.exe to your Desktop
  - If the program is blocked by Windows, click More Info then Run Anyway and if you agree it is safe please click the steps to report the false positive to Microsoft (such as if you have reviewed the source code or reproduced it by building)
    - See the [false positive "severe threat" issue #1](https://github.com/poikilos/DeepFileFind-cs/issues/1)
- Double-click the icon on the desktop (Magnifying glass).
- Push More Info / Allow if you get a security warning.

### Extract or Compile
* If using a git version,
  `git clone https://github.com/expertmm/DeepFileFind.git` then open sln file using
  SharpDevelop, or if using GNU OS install monodevelop then open
  DeepFileFind_monodevelop in MonoDevelop; then set Build configuration
  to Release, then click Build, then Build (Solution or All depending
  on your integrated development environment).
* OR if using a release, unzip release zip to its own folder.

### Install GNU OS
* open terminal
* cd to folder where unzipped
* then: `sudo ./install`


## Key features
* Search partial name (without requiring any type of wildcard notation)
* Modification Date Range (time is optional for each)
* Open a found file by right-clicking on a result file (or optionally open the folder that contains it)
* Saves all possible settings to the user's profile (such as %APPDATA%\DeepFileFind\)


## Directives
* Intuitive: just try to use it and it works
* For average users (has justifiable and readily usable defaults; no regex (except perhaps an invisible option via settings file in the future)--it is unnecessary, and showing an option to use "regex" or "regular expressions" only serves to confuse most people)
* Isn't annoying (no search index; will never have panels other than search and results; no tabs)
* Skipping or modifying any of these directives will make it like any other search tool and therefore irrelevant.
* Cross-platform


## Known Issues	
* Can't see "bytes" labels in form editor
* UI is nonresponsive during search except between files
* Make all savable variables always use dictionary, otherwise MainFormFormClosing and MainFormLoad must have the same list of variables, otherwise the mismatched settings aren't saved & loaded correctly
* Sort again at end of search
* Fix flicker on list when each file is found
* Warn&confirm if results would be every file in folder
* Search within zip files optionally
* Search content of zipped XML files (*.*x office files, and iWork(R) files)


## Changes
See [changelog.md](changelog.md).
