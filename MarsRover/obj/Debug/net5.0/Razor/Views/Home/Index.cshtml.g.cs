#pragma checksum "C:\Users\cosin\Desktop\Wedding Shop\MarsRover\MarsRover\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5eea2bbaaade6cd2ca6f804b9bd0837c2d739caa"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\cosin\Desktop\Wedding Shop\MarsRover\MarsRover\Views\_ViewImports.cshtml"
using MarsRover;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\cosin\Desktop\Wedding Shop\MarsRover\MarsRover\Views\_ViewImports.cshtml"
using MarsRover.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5eea2bbaaade6cd2ca6f804b9bd0837c2d739caa", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7d4703aad5fa10ddfe3e6b7a9ec812c484d3df8b", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\cosin\Desktop\Wedding Shop\MarsRover\MarsRover\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""column-layout"" v-cloak>
    <div class=""control-panel"">
        <div class=""sidebar"">
            <div class=""pane"">
                <div>
                    <h3>Plateu Settings</h3>
                    <div class=""form-group"">
                        <label for=""exampleInputEmail1"">Width</label>
                        <input type=""number"" v-model=""plateuSize.width"" placeholder=""Width"" class=""form-control"" />
                        <small id=""emailHelp"" class=""form-text text-muted"">Set the plateu width in miles</small>
                        <small class=""error"">{{displayError(""Width"")}}</small>
                    </div>
                    <div class=""form-group"">
                        <label for=""exampleInputEmail1"">Height</label>
                        <input type=""number"" v-model=""plateuSize.height"" placeholder=""Height"" class=""form-control"" />
                        <small id=""emailHelp"" class=""form-text text-muted"">Set the plateu height in miles</small>
            ");
            WriteLiteral(@"            <small class=""error"">{{displayError(""Height"")}}</small>
                    </div>
                    <button type=""button"" class=""btn btn-primary"" v-on:click=""setPlateu"">Set Plateu!</button>
                </div>
                <div v-if=""settingPlateu"">Wait, we are setting the plateu</div>
                <div class=""padding-md"" v-if=""plateu != null && plateu != undefined"">
                    <h3>New Rover Settings</h3>
                    <div class=""form-group"">
                        <label for=""exampleInputEmail1"">X Coordinate</label>
                        <input type=""number"" v-model=""newRover.x"" min=""0"" :max=""maxX"" placeholder=""x coordinate"" class=""form-control"" />
                        <small class=""error"">{{displayError(""X"")}}</small>
                    </div>
                    <div class=""form-group"">
                        <label for=""exampleInputEmail1"">Y Coordinate</label>
                        <input type=""number"" v-model=""newRover.y"" min=""0"" :max=""maxY""");
            WriteLiteral(@" placeholder=""w coordinate"" class=""form-control"" />
                        <small class=""error"">{{displayError(""Y"")}}</small>
                    </div>
                    <div class=""form-group"">
                        <label for=""exampleInputEmail1"">Direction</label>
                        <div>
                            <span class=""direction""
                                  :class=""{'selected':newRover.direction == d}""
                                  v-for=""d in directions""
                                  v-on:click=""newRover.direction = d"">
                                {{d}}
                            </span>
                        </div>
                        <small id=""emailHelp"" class=""form-text text-muted"">Set what direction a new rover should be facing</small>
                    </div>
                    <button type=""button"" class=""btn btn-primary"" v-on:click=""launcRover"">Launch Rover!</button>

                </div>
                <div class=""padding-md"" v-");
            WriteLiteral(@"if=""rovers.length > 0"">
                    <h3>Active rovers</h3>
                    <div v-for=""r in rovers"" class=""rover-active"">
                        <h5>Rover ID <small class=""roverid"">{{r.id}}</small></h5>
                        X:{{r.x}}, Y:{{r.y}}, Facing:{{r.direction}}
                        <span class=""control-rover-commands pull-right"">
                            <span class=""rover-coomand""
                                  :class=""{selected:c == r.selectedCommand}""
                                  v-for=""c in r.commands""
                                  v-on:click=""move(r,c)"">{{c}}</span>
                        </span>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class=""col-md-9"">
        <div class=""text-center"" v-cloak>
            <h1 class=""display-4"">{{message}}</h1>
        </div>
        <div class=""container"">
            <div class=""row"" v-if=""plateu != null && plateu != undefined"">
              ");
            WriteLiteral(@"  <div class=""plateu"">
                    <div v-for=""x in plateu.heightArr"">
                        <div class=""plateu-area"" v-for=""y in plateu.widthArr"">
                            <span class=""area-coordinates"">x:{{y}}, y:{{x}} </span>
                            <div class=""rover"" v-for=""rover in areaRovers(y,x)"">
                                R <i :class=""getDirection(rover.direction)""></i>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>

");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591