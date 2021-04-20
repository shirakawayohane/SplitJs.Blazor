# SplitJs.Blazor

[![Build and Test](https://github.com/WiZ3910/SplitJs.Blazor/actions/workflows/build-debug.yml/badge.svg)](https://github.com/WiZ3910/SplitJs.Blazor/actions/workflows/build-debug.yml)
[![Release](https://github.com/WiZ3910/SplitJs.Blazor/actions/workflows/publish-nuget-package.yml/badge.svg?event=push)](https://github.com/WiZ3910/SplitJs.Blazor/actions/workflows/publish-nuget-package.yml)

A component wrapper of split.js for Blazor.

![splitjs_blazor_demo](https://user-images.githubusercontent.com/7351910/115134748-e7fd5f80-a04d-11eb-8e79-5a25f8cad462.gif)

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
- Enable Nullable in your project
```cs
<Nullable>enable</Nullable>
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

## Special Thanks
Split.js author
https://github.com/nathancahill/
