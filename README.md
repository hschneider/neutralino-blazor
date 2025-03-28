</p>

# neutralino-blazor

**Run C# Blazor Desktop Apps on Linux, chromeOS, macOS and Windows**

This app scaffold comes with the following features:
- Run a Blazor WASM app in a Neutralino Webview.
- Deploy your desktop app to Linux and chromeOS, which is not possible with native Blazor MAUI.
- Access all system-resources from the Blazor WASM sandbox through Neutralino's powerful API.
- Use all available [Neutralino Extensions](https://neutralino.js.org/resources/) from your C# code.
- Bypass CORS issues with e.g. [Neutralino's CURL extension](https://github.com/hschneider/neutralino-curl).
- Comes with only the code you really need.
- MudBlazor integrated.

<img src="https://marketmix.com/git-assets/neutralino-blazor/neutralino-blazor-wasm-linux.jpg">

## Neutralino & Blazor: How to integrate
Clone this repo and setup your Neutralino environment as usual. Go to the _dotnet folder and create your Blazor WASM app:
```bash
cd _dotnet
dotnet new blazorwasm -n myapp
```
When your app is ready to publish, add these 2 lines in `wwwroot/index.html` before the closing body-tag:
```html
<script src="js/neutralino.js"></script>
<script src="js/main.js"></script>
```
Publish your app with
```bash
cd myapp
dotnet publish -c Release
```
Then copy the content of `bin/Release/net9.0/publish/wwwroot/` to Neutralino's resources folder.

Make sure, that these 2 folders do not get lost:
- resources/js
- resources/icons

The `_dotnet/publish.sh` script does all these steps for the demo app included. The modified `index.html` is located in `_dotnet/resources` and copied as well.

After publishing you can run the app with:
```bash
neu run
```
<p align="center">
<img src="https://marketmix.com/git-assets/neutralino-blazor/neutralino-blazor-app.jpg" style="max-width:400px">
</p>
## How does it work?
The Blazor WASM file runs in Neutralino's webview inside a native OS window.

The 2 lines added to the index.html make the Neutralino API accessible from Javascript.

This simple example illustrates how to call JS code from C#, doing things outside the WASM sandbox:

```html
@page "/"
@using neutralino_blazor.Services
@inject ApiDatabase Api
@inject Globals Globals
@inject IJSRuntime JS

<MudText Typo="Typo.h2">Hello World!</MudText>
<MudText Style="margin-bottom: 20px">Built with MudBlazor.</MudText>

<div style="margin-top: 20px">
    <MudButton Variant="Variant.Filled" Color="Color.Primary" DropShadow="false" @onclick="OnTestNeutralinoAPI">Call the Neutralino API</MudButton>
</div>

@code {
    private async Task OnTestNeutralinoAPI()
    {
        await JS.InvokeVoidAsync("Neutralino.os.showMessageBox", "Info", "Neutralino says: Hi Blazor!");
    }
}
```
We do an async call to the Neutralino API by using Blazor's JS InterOp, here the API-function `Neutralino.os.showMessageBox("Info", "Neutralino says: Hi Blazor!")`.

So when you click the "Call the Neutralino API" button, an os-native dialog pops up. 

You can also do more complex calls or call C# code from JS. Read more [about Blazor's JS InterOp here](https://learn.microsoft.com/en-us/aspnet/core/blazor/javascript-interoperability/?view=aspnetcore-9.0).

## More about Neutralino

- [NeutralinoJS Home](https://neutralino.js.org) 
- [Neutralino related blog posts at marketmix.com](https://marketmix.com/de/tag/neutralinojs/)


<img src="https://marketmix.com/git-assets/star-me-2.svg">

