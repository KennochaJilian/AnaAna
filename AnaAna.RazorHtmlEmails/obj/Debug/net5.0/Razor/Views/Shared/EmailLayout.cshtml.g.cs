#pragma checksum "C:\Users\codin\Documents\Projets CCI\C#-ASP-net\AnaAna\AnaAna.RazorHtmlEmails\Views\Shared\EmailLayout.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a9bf01c45aa0f94020c53194fe4561c38a818a03"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_EmailLayout), @"mvc.1.0.view", @"/Views/Shared/EmailLayout.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a9bf01c45aa0f94020c53194fe4561c38a818a03", @"/Views/Shared/EmailLayout.cshtml")]
    public class Views_Shared_EmailLayout : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("background-color: #f4f4f4; margin: 0 !important; padding: 0 !important;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<!DOCTYPE html>\r\n<html>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a9bf01c45aa0f94020c53194fe4561c38a818a033180", async() => {
                WriteLiteral(@"
    <title></title>
    <meta http-equiv=""Content-Type"" content=""text/html; charset=utf-8"" />
    <meta name=""viewport"" content=""width=device-width, initial-scale=1"">
    <meta http-equiv=""X-UA-Compatible"" content=""IE=edge"" />
    <style type=""text/css"">
        /* FONTS */
        ");
                WriteLiteral("@media screen {\r\n            ");
                WriteLiteral(@"@font-face {
                font-family: 'Lato';
                font-style: normal;
                font-weight: 400;
                src: local('Lato Regular'), local('Lato-Regular'), url(https://fonts.gstatic.com/s/lato/v11/qIIYRU-oROkIk8vfvxw6QvesZW2xOQ-xsNqO47m55DA.woff) format('woff');
            }
            ");
                WriteLiteral(@"@font-face {
                font-family: 'Lato';
                font-style: normal;
                font-weight: 700;
                src: local('Lato Bold'), local('Lato-Bold'), url(https://fonts.gstatic.com/s/lato/v11/qdgUG4U09HnJwhYI-uK18wLUuEpTyoUstqEm5AMlJo4.woff) format('woff');
            }
            ");
                WriteLiteral(@"@font-face {
                font-family: 'Lato';
                font-style: italic;
                font-weight: 400;
                src: local('Lato Italic'), local('Lato-Italic'), url(https://fonts.gstatic.com/s/lato/v11/RYyZNoeFgb0l7W3Vu1aSWOvvDin1pK8aKteLpeZ5c0A.woff) format('woff');
            }
            ");
                WriteLiteral(@"@font-face {
                font-family: 'Lato';
                font-style: italic;
                font-weight: 700;
                src: local('Lato Bold Italic'), local('Lato-BoldItalic'), url(https://fonts.gstatic.com/s/lato/v11/HkF_qI1x_noxlxhrhMQYELO3LdcAZYWl9Si6vvxL-qU.woff) format('woff');
            }
        }
        img {
            -ms-interpolation-mode: bicubic;
        }
        /* RESET STYLES */
        img {
            border: 0;
            height: auto;
            line-height: 100%;
            outline: none;
            text-decoration: none;
        }
        table {
            border-collapse: collapse !important;
        }
        body {
            height: 100% !important;
            margin: 0 !important;
            padding: 0 !important;
            width: 100% !important;
        }
        /* iOS BLUE LINKS */
        a[x-apple-data-detectors] {
            color: inherit !important;
            text-decoration: none !important;
            f");
                WriteLiteral("ont-size: inherit !important;\r\n            font-family: inherit !important;\r\n            font-weight: inherit !important;\r\n            line-height: inherit !important;\r\n        }\r\n        /* MOBILE STYLES */\r\n        ");
                WriteLiteral(@"@media screen and (max-width:600px) {
            h1 {
                font-size: 32px !important;
                line-height: 32px !important;
            }
        }
        /* ANDROID CENTER FIX */
        div[style*=""margin: 16px 0;""] {
            margin: 0 !important;
        }
    </style>
");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a9bf01c45aa0f94020c53194fe4561c38a818a037264", async() => {
                WriteLiteral(@"

    <table border=""0"" cellpadding=""0"" cellspacing=""0"" width=""100%"">
        <tr>
            <td bgcolor=""#6FA43F"" align=""center"">
                <table align=""center"" border=""0"" cellspacing=""0"" cellpadding=""0"" width=""600"">
                <tr>
                <td align=""center"" valign=""top"" width=""600"">
                <table border=""0"" cellpadding=""0"" cellspacing=""0"" width=""100%"" style=""max-width: 600px;"">
                    <tr>
                        <td align=""center"" valign=""top"" style=""padding: 40px 10px 40px 10px;"">
                            <a");
                BeginWriteAttribute("href", " href=\"", 3549, "\"", 3556, 0);
                EndWriteAttribute();
                WriteLiteral(@" target=""_blank"">
                                <img alt=""Logo"" src=""https://lh3.googleusercontent.com/MAiQdP9MjhVKbS59PxDfi8yBCBuBwNGvskp82K7KjCeKOpEMEQd4W-Ic2CYrkSAPtSUSvhOEddmgHT-1bv-OfRF-7lgxgNftZ0Gzng2N_UTbFywWY-bVF-KCuIZrT2VxB5u4kk-CeAuU_Q9VUktLGyOGxJvWF7QomhkzGuCWTagMPXADzcvnunkr7_A8zqitTWfYlWJtKYDZ664YrMYDjHMvfZs0_5Fg0JOudzVnw8iAMagGwdCRWmbnldNRUAcbXCI4we1NwoLhRK9ViFlV4W0MxiJmgxyx6yqiPQob5I8zY1wmgPFfRobmXo1Ma_ipC9p8qgVsTXfI-mQ84F9mMRKjh6MKykQ5NO47rzzo0xA8oLW8eizaIL2Qmg4gZTbZKuATvgBoYOqw9yhWMweF6AgjD0omOrhp9oAeMxxeRqVvW2V4fRcx7xFNk3uvSg_Xn8XkCtxnjuHAjihuLO2E5bWmcgzntxkzxWCheKYa91S5Ecc4JWfIIucLHxHcsXElcqbc1DeWsa4Ix-gWOGVLjEp1QETmOwwXMi8gznawHA0yc2_lJT0RyZ-VhAz0M21dJO765N3IDdIJSb1R1Yriqe77Ax7Fvnpdh8XRfNXUE-UBi7nrct5quQ7vwkt8V9TKBo42_Oiy0QRV6Vv1O-fOFUSH-7Vaeq-SNW3qLi_GIi8yEAgmdTlCw7z37R2x8Q_UXKoY6qHWowi-rIxRHHUOWmRC=w640-h639-no?authuser=0"" width=""40"" height=""40"" style=""display: block; width: 100px; max-width: 100px; min-width: 100px; font-family: 'Lato', Helvetica, Arial, sans-serif; color: #ffffff; f");
                WriteLiteral(@"ont-size: 18px;"" border=""0"">
                            </a>
                        </td>
                    </tr>
                    <tr>
                        <td align=""center"" valign=""top"" style=""padding: 0px 0px 0px 0px;"">
                            <h1 align=""center"" style=""display: block; font-family: 'Lato', Helvetica, Arial, sans-serif; color: #ffffff; font-size: 30px; margin:0; margin-bottom: 20px; ""> AnaAna </h1>
                        </td>
                    </tr>
                </table>
                </td>
                </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td bgcolor=""#6FA43F"" align=""center"" style=""padding: 0px 10px 0px 10px;"">
                <table align=""center"" border=""0"" cellspacing=""0"" cellpadding=""0"" width=""600"">
                <tr>
                <td align=""center"" valign=""top"" width=""600"">
                <table border=""0"" cellpadding=""0"" cellspacing=""0"" width=""100%"" style=""max-width: 600px;"">
     ");
                WriteLiteral(@"               <tr>
                        <td bgcolor=""#ffffff"" align=""center"" valign=""top"" style=""padding: 40px 20px 20px 20px; border-radius: 4px 4px 0px 0px; color: #111111; font-family: 'Lato', Helvetica, Arial, sans-serif; font-size: 48px; font-weight: 400; letter-spacing: 4px; line-height: 48px;"">
                            <h1 style=""font-size: 48px; font-weight: 400; margin: 0;"">");
#nullable restore
#line 113 "C:\Users\codin\Documents\Projets CCI\C#-ASP-net\AnaAna\AnaAna.RazorHtmlEmails\Views\Shared\EmailLayout.cshtml"
                                                                                 Write(ViewData["EmailTitle"]);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"</h1>
                        </td>
                    </tr>
                </table>
                </td>
                </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td bgcolor=""#f4f4f4"" align=""center"" style=""padding: 0px 10px 0px 10px;"">
                <table align=""center"" border=""0"" cellspacing=""0"" cellpadding=""0"" width=""600"">
                <tr>
                <td align=""center"" valign=""top"" width=""600"">
                <table border=""0"" cellpadding=""0"" cellspacing=""0"" width=""100%"" style=""max-width: 600px;"">
                    <tr>
                        <td bgcolor=""#ffffff"" align=""left"" style=""padding: 20px 30px 40px 30px; color: #666666; font-family: 'Lato', Helvetica, Arial, sans-serif; font-size: 18px; font-weight: 400; line-height: 25px;"">
                            ");
#nullable restore
#line 130 "C:\Users\codin\Documents\Projets CCI\C#-ASP-net\AnaAna\AnaAna.RazorHtmlEmails\Views\Shared\EmailLayout.cshtml"
                       Write(RenderBody());

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                           
                        </td>
                    </tr>
                </table>
                </td>
                </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td bgcolor=""#f4f4f4"" align=""center"" style=""padding: 0px 10px 0px 10px;"">
                <table align=""center"" border=""0"" cellspacing=""0"" cellpadding=""0"" width=""600"">
                <tr>
                <td align=""center"" valign=""top"" width=""600"">
                <table border=""0"" cellpadding=""0"" cellspacing=""0"" width=""100%"" style=""max-width: 600px;"">                    
                    <tr>
                        <td bgcolor=""#f4f4f4"" align=""left"" style=""padding: 0px 30px 30px 30px; color: #666666; font-family: 'Lato', Helvetica, Arial, sans-serif; font-size: 14px; font-weight: 400; line-height: 18px;"">
                            <p style=""margin: 0;"">Ce mail vous a été envoyé puisque vous avez créé un sondage sur AnaAna</p>
                        </t");
                WriteLiteral(@"d>
                    </tr>
                    <tr>
                        <td bgcolor=""#f4f4f4"" align=""left"" style=""padding: 0px 30px 30px 30px; color: #666666; font-family: 'Lato', Helvetica, Arial, sans-serif; font-size: 14px; font-weight: 400; line-height: 18px;"">
                            <p style=""margin: 0;"">AnaAna est un projet d'école pour le titre Concepteur développeur d'application 2022</p>
                        </td>
                    </tr>
                    <tr>
                        <td bgcolor=""#f4f4f4"" align=""left"" style=""padding: 0px 30px 30px 30px; color: #666666; font-family: 'Lato', Helvetica, Arial, sans-serif; font-size: 14px; font-weight: 400; line-height: 18px;"">
                            <p style=""margin: 0;"">AnaAna - 1234 Main Street – Anywhere, MA – 56789 </p>
                        </td>
                    </tr>
                </table>
                </td>
                </tr>
                </table>
            </td>
        </tr>
    </tabl");
                WriteLiteral("e>\r\n\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</html>");
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
