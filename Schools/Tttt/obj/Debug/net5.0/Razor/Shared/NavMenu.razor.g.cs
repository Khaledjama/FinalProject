#pragma checksum "F:\FinalProject\Schools\Tttt\Shared\NavMenu.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1f502a08d25bb99c5a90dd7c73167b79bccf1112"
// <auto-generated/>
#pragma warning disable 1591
namespace Tttt.Shared
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "F:\FinalProject\Schools\Tttt\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "F:\FinalProject\Schools\Tttt\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "F:\FinalProject\Schools\Tttt\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "F:\FinalProject\Schools\Tttt\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "F:\FinalProject\Schools\Tttt\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "F:\FinalProject\Schools\Tttt\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "F:\FinalProject\Schools\Tttt\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "F:\FinalProject\Schools\Tttt\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "F:\FinalProject\Schools\Tttt\_Imports.razor"
using Tttt;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "F:\FinalProject\Schools\Tttt\_Imports.razor"
using Tttt.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "F:\FinalProject\Schools\Tttt\_Imports.razor"
using Schools.DataStorage.Entity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "F:\FinalProject\Schools\Tttt\_Imports.razor"
using Blazored.Toast;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "F:\FinalProject\Schools\Tttt\_Imports.razor"
using Blazored.Toast.Services;

#line default
#line hidden
#nullable disable
    public partial class NavMenu : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, "<link rel=\"stylesheet\" href=\"~/pluto-1.0.0/css/animate.css\" b-ihhhvrnfzu>\n<link rel=\"stylesheet\" href=\"~/pluto-1.0.0/css/perfect-scrollbar.css\" b-ihhhvrnfzu>\n\n\n<link rel=\"stylesheet\" href=\"~/pluto-1.0.0/style.css\" b-ihhhvrnfzu>\n");
            __builder.AddMarkupContent(1, "<nav id=\"sidebar\" b-ihhhvrnfzu><div class=\"sidebar_blog_1\" b-ihhhvrnfzu><div class=\"sidebar-header\" b-ihhhvrnfzu><div class=\"logo_section\" b-ihhhvrnfzu><a href=\"index.html\" b-ihhhvrnfzu><img class=\"logo_icon img-responsive\" src=\"/pluto-1.0.0/images/logo/logo_icon.png\" alt=\"#\" b-ihhhvrnfzu></a></div></div>\n        <div class=\"sidebar_user_info\" b-ihhhvrnfzu><div class=\"icon_setting\" b-ihhhvrnfzu></div>\n            <div class=\"user_profle_side\" b-ihhhvrnfzu><div class=\"user_img\" b-ihhhvrnfzu><img class=\"img-responsive\" src=\"/pluto-1.0.0/images/layout_img/user_img.jpg\" alt=\"#\" b-ihhhvrnfzu></div>\n                <div class=\"user_info\" b-ihhhvrnfzu><h6 b-ihhhvrnfzu>John David</h6>\n                    <p b-ihhhvrnfzu><span class=\"online_animation\" b-ihhhvrnfzu></span> Online</p></div></div></div></div>\n    <div class=\"sidebar_blog_2\" b-ihhhvrnfzu><h4 b-ihhhvrnfzu>General</h4>\n        <ul class=\"list-unstyled components\" b-ihhhvrnfzu><li class=\"active\" b-ihhhvrnfzu><a href=\"#dashboard\" data-toggle=\"collapse\" aria-expanded=\"false\" class=\"dropdown-toggle\" b-ihhhvrnfzu><i class=\"fa fa-dashboard yellow_color\" b-ihhhvrnfzu></i> <span b-ihhhvrnfzu>Dashboard</span></a>\n                <ul class=\"collapse list-unstyled\" id=\"dashboard\" b-ihhhvrnfzu><li b-ihhhvrnfzu><a href=\"dashboard.html\" b-ihhhvrnfzu>> <span b-ihhhvrnfzu>Default Dashboard</span></a></li>\n                    <li b-ihhhvrnfzu><a href=\"dashboard_2.html\" b-ihhhvrnfzu>> <span b-ihhhvrnfzu>Dashboard style 2</span></a></li></ul></li>\n            <li b-ihhhvrnfzu><a href=\"widgets.html\" b-ihhhvrnfzu><i class=\"fa fa-clock-o orange_color\" b-ihhhvrnfzu></i> <span b-ihhhvrnfzu>Widgets</span></a></li>\n            <li b-ihhhvrnfzu><a href=\"#element\" data-toggle=\"collapse\" aria-expanded=\"false\" class=\"dropdown-toggle\" b-ihhhvrnfzu><i class=\"fa fa-diamond purple_color\" b-ihhhvrnfzu></i> <span b-ihhhvrnfzu>Elements</span></a>\n                <ul class=\"collapse list-unstyled\" id=\"element\" b-ihhhvrnfzu><li b-ihhhvrnfzu><a href=\"general_elements.html\" b-ihhhvrnfzu>> <span b-ihhhvrnfzu>General Elements</span></a></li>\n                    <li b-ihhhvrnfzu><a href=\"media_gallery.html\" b-ihhhvrnfzu>> <span b-ihhhvrnfzu>Media Gallery</span></a></li>\n                    <li b-ihhhvrnfzu><a href=\"icons.html\" b-ihhhvrnfzu>> <span b-ihhhvrnfzu>Icons</span></a></li>\n                    <li b-ihhhvrnfzu><a href=\"invoice.html\" b-ihhhvrnfzu>> <span b-ihhhvrnfzu>Invoice</span></a></li></ul></li>\n            <li b-ihhhvrnfzu><a href=\"tables.html\" b-ihhhvrnfzu><i class=\"fa fa-table purple_color2\" b-ihhhvrnfzu></i> <span b-ihhhvrnfzu>Tables</span></a></li>\n            <li b-ihhhvrnfzu><a href=\"#apps\" data-toggle=\"collapse\" aria-expanded=\"false\" class=\"dropdown-toggle\" b-ihhhvrnfzu><i class=\"fa fa-object-group blue2_color\" b-ihhhvrnfzu></i> <span b-ihhhvrnfzu>Apps</span></a>\n                <ul class=\"collapse list-unstyled\" id=\"apps\" b-ihhhvrnfzu><li b-ihhhvrnfzu><a href=\"email.html\" b-ihhhvrnfzu>> <span b-ihhhvrnfzu>Email</span></a></li>\n                    <li b-ihhhvrnfzu><a href=\"calendar.html\" b-ihhhvrnfzu>> <span b-ihhhvrnfzu>Calendar</span></a></li>\n                    <li b-ihhhvrnfzu><a href=\"media_gallery.html\" b-ihhhvrnfzu>> <span b-ihhhvrnfzu>Media Gallery</span></a></li></ul></li>\n            <li b-ihhhvrnfzu><a href=\"price.html\" b-ihhhvrnfzu><i class=\"fa fa-briefcase blue1_color\" b-ihhhvrnfzu></i> <span b-ihhhvrnfzu>Pricing Tables</span></a></li>\n            <li b-ihhhvrnfzu><a href=\"contact.html\" b-ihhhvrnfzu><i class=\"fa fa-paper-plane red_color\" b-ihhhvrnfzu></i> <span b-ihhhvrnfzu>Contact</span></a></li>\n            <li class=\"active\" b-ihhhvrnfzu><a href=\"#additional_page\" data-toggle=\"collapse\" aria-expanded=\"false\" class=\"dropdown-toggle\" b-ihhhvrnfzu><i class=\"fa fa-clone yellow_color\" b-ihhhvrnfzu></i> <span b-ihhhvrnfzu>Additional Pages</span></a>\n                <ul class=\"collapse list-unstyled\" id=\"additional_page\" b-ihhhvrnfzu><li b-ihhhvrnfzu><a href=\"profile.html\" b-ihhhvrnfzu>> <span b-ihhhvrnfzu>Profile</span></a></li>\n                    <li b-ihhhvrnfzu><a href=\"project.html\" b-ihhhvrnfzu>> <span b-ihhhvrnfzu>Projects</span></a></li>\n                    <li b-ihhhvrnfzu><a href=\"login.html\" b-ihhhvrnfzu>> <span b-ihhhvrnfzu>Login</span></a></li>\n                    <li b-ihhhvrnfzu><a href=\"404_error.html\" b-ihhhvrnfzu>> <span b-ihhhvrnfzu>404 Error</span></a></li></ul></li>\n            <li b-ihhhvrnfzu><a href=\"map.html\" b-ihhhvrnfzu><i class=\"fa fa-map purple_color2\" b-ihhhvrnfzu></i> <span b-ihhhvrnfzu>Map</span></a></li>\n            <li b-ihhhvrnfzu><a href=\"charts.html\" b-ihhhvrnfzu><i class=\"fa fa-bar-chart-o green_color\" b-ihhhvrnfzu></i> <span b-ihhhvrnfzu>Charts</span></a></li>\n            <li b-ihhhvrnfzu><a href=\"settings.html\" b-ihhhvrnfzu><i class=\"fa fa-cog yellow_color\" b-ihhhvrnfzu></i> <span b-ihhhvrnfzu>Settings</span></a></li></ul></div></nav>");
        }
        #pragma warning restore 1998
    }
}
#pragma warning restore 1591
