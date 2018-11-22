#pragma checksum "/Users/onolinus/Documents/Data/project/paypont/PaypontCode/Paypont/Paypont/Views/Home/Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6c0e7dd16e24b58b5c1a8da346062eee55c084dc"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Index.cshtml", typeof(AspNetCore.Views_Home_Index))]
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
#line 1 "/Users/onolinus/Documents/Data/project/paypont/PaypontCode/Paypont/Paypont/Views/_ViewImports.cshtml"
using Paypont;

#line default
#line hidden
#line 2 "/Users/onolinus/Documents/Data/project/paypont/PaypontCode/Paypont/Paypont/Views/_ViewImports.cshtml"
using Paypont.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6c0e7dd16e24b58b5c1a8da346062eee55c084dc", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"57e628d35e8e957086117de1ca518d23f63aa5b9", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "/Users/onolinus/Documents/Data/project/paypont/PaypontCode/Paypont/Paypont/Views/Home/Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
            BeginContext(45, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            DefineSection("styles", async() => {
                BeginContext(64, 118, true);
                WriteLiteral("\r\n    <link rel=\"stylesheet\" type=\"text/css\" href=\"https://cdn.datatables.net/v/dt/dt-1.10.13/datatables.min.css\" />\r\n");
                EndContext();
            }
            );
            BeginContext(185, 880, true);
            WriteLiteral(@"
<div class=""row"">
    <div class=""col-md-12"">
        <div class=""panel panel-primary"">
            <div class=""panel-heading"">
                <h3 class=""panel-title"">Customer</h3>
            </div>
            <div class=""panel-body"">
                <table id=""CustomerTable"" class=""table table-striped table-bordered table-hover responsive"" width=""100%"">
                    <thead class=""thin-border-bottom"">
                        <tr>
                            <th>ID</th>
                            <th>FirstName</th>
                            <th>SurName</th>
                            <th>StreetAddress</th>
                            <th>City</th>
                            <th>PostCode</th>
                        </tr>
                    </thead>
                </table>
            </div>
        </div>
    </div>
</div>


");
            EndContext();
            DefineSection("scripts", async() => {
                BeginContext(1083, 946, true);
                WriteLiteral(@"
    <script type=""text/javascript"" src=""https://cdn.datatables.net/v/dt/dt-1.10.13/datatables.min.js""></script>
    <script>
    (function($) {
        var generateCustomerTable = $(""#CustomerTable"")
        .dataTable({
          language: {
                searchPlaceholder: ""Search by Surname""
             },
          ""processing"": true,
          ""serverSide"": true,
          ""ajax"": {
              ""url"": ""/api/customer"",
              ""method"": ""POST""
          },
          ""columns"": [
            { ""data"": ""id"" },
            { ""data"": ""firstName"" },
            { ""data"": ""sureName"" },
            { ""data"": ""streetAddress"" },
            { ""data"": ""city"" },
            { ""data"": ""postCode"" }
          ],
          ""searching"":true,
          ""ordering"": true,
          ""paging"": true,
          ""pagingType"": ""full_numbers"",
          ""pageLength"": 10
        });
    })(jQuery);
    </script>
");
                EndContext();
            }
            );
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
