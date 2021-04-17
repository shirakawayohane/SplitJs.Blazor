# SplitJs.Blazor
[![Pack and publish nuget package.](https://github.com/WiZ3910/SplitJs.Blazor/actions/workflows/publish-nuget-package.yml/badge.svg)](https://github.com/WiZ3910/SplitJs.Blazor/actions/workflows/publish-nuget-package.yml)

This is a component wrapper of split.js for Blazor.

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
<SplitZone>
    <Vertical GutterSize="10">
        <Split MinSizePx="0" Style="height: 300px">
            <p>Upper</p>
        </Split>
        <Split MinSizePx="0">
            <Horizontal GutterSize="10">
                <Split Size="40" MinSizePx="0">
                    Lower Left
                </Split>
                <Split Size="60" MinSizePx="0">
                    Lower Right
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