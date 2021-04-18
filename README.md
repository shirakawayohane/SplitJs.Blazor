# SplitJs.Blazor

[![Build and test](https://github.com/WiZ3910/SplitJs.Blazor/actions/workflows/build-debug.yml/badge.svg)](https://github.com/WiZ3910/SplitJs.Blazor/actions/workflows/build-debug.yml)
[![Publish](https://github.com/WiZ3910/SplitJs.Blazor/actions/workflows/publish-nuget-package.yml/badge.svg)](https://github.com/WiZ3910/SplitJs.Blazor/actions/workflows/publish-nuget-package.yml)

A component wrapper of split.js for Blazor.

![demo](https://gyazo.com/1ad06abffe27a8c4185cf6f65dd8a5a0)

See also https://github.com/nathancahill/split/tree/master/packages/splitjs
## Installation
Installation is super easy.

- Add Nuget Package
```
dotnet add package SplitJs.Blazor
```
- Add namespace reference to your ```_Imports.razor```
```cs
@using SplitJs.Blazor.Components 
```

## Components
This component lib has 4 components in all.
### ```<SplitZone>```
First, you need to place ```<SplitZone>``` anyway.
Why this component is required is because this component has some basic CSS classes, which are necessary to work with split.js.

### ```<Horizontal>```
This component will render children ```<Split>``` component as horizontally split columns.
### ```<Vertical>```
This component will render children ```<Split>``` component as vertically split rows.
See also [Important note](#important-note)
### ```<Split>```
This component is the most basic component that will be rendered as split columns/rows working with ```<Horizontal>``` or  ```<Vertical>``` components.

## Sample
```html
<SplitZone Style="height:500px;">
    <Vertical GutterSize="10">
        <Split MinSizePx="0" Style="background-color:#b6ff00">
            <h1>
                Hello!
            </h1>
        </Split>
        <Split MinSizePx="0">
            <Horizontal GutterSize="10">
                <Split Size="40" MinSizePx="0" Style="background-color:#ea9797">
                    <h1>Blazor</h1>
                </Split>
                <Split Size="60" MinSizePx="0" Style="background-color:#639ac8">
                    <h1>Split.js</h1>
                </Split>
            </Horizontal>
        </Split>
    </Vertical>
</SplitZone>

```

## Important Note
Due to split.js limitation, when you want to nest split components like 
```html
<SplitZone>
    <Horizontal>
        <Split>
            <Vertical>
                <Split>
                    Upper Left
                </Split>
                <Split>
                    Lower Left
                </Split>
            </Vertical>
        </Split>
        <Split>
            <Vertical>
                <Split>
                    Upper Right
                </Split>
                <Split>
                    Lower Lower Right
                </Split>
            </Vertical>
        </Split>
    </Horizontal>
</SplitZone>
```
or
```html
<SplitZone>
    <Vertical>
        <Split>
            <Horizontal>
                <Split>
                    Upper Left
                </Split>
                <Split>
                    Lower Left
                </Split>
            </Horizontal>
        </Split>
        <Split>
            <Horizontal>
                <Split>
                    Upper Right
                </Split>
                <Split>
                    Lower Lower Right
                </Split>
            </Horizontal>
        </Split>
    </Vertical>
</SplitZone>
```
, the only latter one will work correctly.
Please __Note that you should use Vertical tag first and enclose Horizontal tag.__




## Special Thanks
Split.js author
https://github.com/nathancahill/