# DeepFileFind
The goal of this project is to create the most satisfying search program in the world. DeepFileFind...

* Has features you need
* Isn't annoying
* Is GPL (free as in freedom, forever--redistribute modify according to the terms as you wish)

--in other words, it's a program like nothing before it.

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

## Changes
* (2017-04-15) Press enter to search (if name or content box has focus)
* (2017-04-15) Ctrl+C can copy path of selected result
* (2017-04-15) Re-enable buttons correctly after nonexistent folder was used
* (2017-04-15) save location at top of recent list; use most recent location on startup; only set a generated value for location on startup if no locations were found
* (2017-04-15) Save content string and name to settings

## Known Issues
* Add wildcard notation
* Fix flicker on list when each file is found
* Implement content search
* Add sorting by any column (sort again at end of search)
* Warn&confirm if results would be every file in folder
* Add created date range
* Search within zip files optionally
* Search content of zipped XML files (*.*x office files, and iWork(R) files)