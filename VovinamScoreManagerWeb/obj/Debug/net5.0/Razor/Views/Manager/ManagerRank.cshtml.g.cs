#pragma checksum "C:\Users\Admin\Downloads\VovinamScoreManagerFix\VovinamScoreManager\VovinamScoreManagerWeb\Views\Manager\ManagerRank.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0e3f66819e8cce0fe48d7a87129be3ba3fa53e44"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Manager_ManagerRank), @"mvc.1.0.view", @"/Views/Manager/ManagerRank.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0e3f66819e8cce0fe48d7a87129be3ba3fa53e44", @"/Views/Manager/ManagerRank.cshtml")]
    #nullable restore
    public class Views_Manager_ManagerRank : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
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
            WriteLiteral("\r\n<html>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0e3f66819e8cce0fe48d7a87129be3ba3fa53e442818", async() => {
                WriteLiteral(@"
	<style>
		.login-page {
			width: 1500px;
			padding: 2% 0 0;
			margin: auto;
		}

		.form {
			position: relative;
			z-index: 1;
			background: #FFFFFF;
			max-width: 1500px;
			margin: 0 auto 50px;
			padding: 45px;
			text-align: center;
			box-shadow: 0 0 20px 0 rgba(0, 0, 0, 0.2), 0 5px 5px 0 rgba(0, 0, 0, 0.24);
		}

			.form input {
				font-family: ""Roboto"", sans-serif;
				outline: 0;
				background: #f2f2f2;
				width: 100%;
				border: 0;
				margin: 0 0 15px;
				padding: 15px;
				box-sizing: border-box;
				font-size: 14px;
			}

			.form button {
				font-family: ""Roboto"", sans-serif;
				text-transform: uppercase;
				outline: 0;
				background: #C0C0C0;
				width: 100%;
				border: 0;
				padding: 15px;
				color: #FFFFFF;
				font-size: 14px;
				-webkit-transition: all 0.3 ease;
				transition: all 0.3 ease;
				cursor: pointer;
			}

				.form button:hover, .form button:active, .form button:focus {
					background: #808080;
				}

			.f");
                WriteLiteral(@"orm .message {
				margin: 15px 0 0;
				color: #b3b3b3;
				font-size: 12px;
			}

				.form .message a {
					color: #C0C0C0;
					text-decoration: none;
				}

			.form .register-form {
				display: none;
			}

		.container {
			position: relative;
			z-index: 1;
			max-width: 300px;
			margin: 0 auto;
		}

			.container:before, .container:after {
				content: """";
				display: block;
				clear: both;
			}

			.container .info {
				margin: 50px auto;
				text-align: center;
			}

				.container .info h1 {
					margin: 0 0 15px;
					padding: 0;
					font-size: 36px;
					font-weight: 300;
					color: #1a1a1a;
				}

				.container .info span {
					color: #4d4d4d;
					font-size: 12px;
				}

					.container .info span a {
						color: #000000;
						text-decoration: none;
					}

					.container .info span .fa {
						color: #EF3B3A;
					}

		body {
			background: #00CCFF; /* fallback for old browsers */
			background: #00CCCC;
			background: line");
                WriteLiteral(@"ar-gradient(90deg, #CC9933 0%, #FF9900 50%);
			font-family: ""Roboto"", sans-serif;
			-webkit-font-smoothing: antialiased;
			-moz-osx-font-smoothing: grayscale;
		}

		.topnav {
			overflow: hidden;
			background-color: #333;
		}

			.topnav a {
				float: left;
				display: block;
				color: #f2f2f2;
				text-align: center;
				padding: 14px 16px;
				text-decoration: none;
				font-size: 17px;
			}

				.topnav a:hover {
					background-color: #ddd;
					color: black;
				}

				.topnav a.active {
					background-color: blue;
					color: white;
				}

			.topnav .icon {
				display: none;
			}

		.footer-clean {
			padding: 50px 0;
			background-color: #fff;
			color: #4b4c4d;
		}

			.footer-clean h3 {
				margin-top: 0;
				margin-bottom: 12px;
				font-weight: bold;
				font-size: 16px;
			}

			.footer-clean ul {
				padding: 0;
				list-style: none;
				line-height: 1.6;
				font-size: 14px;
				margin-bottom: 0;
			}

				.footer-clean ul a {
	");
                WriteLiteral(@"				color: inherit;
					text-decoration: none;
					opacity: 0.8;
				}

					.footer-clean ul a:hover {
						opacity: 1;
					}

			.footer-clean .item.social {
				text-align: right;
			}

				.footer-clean .item.social > a {
					font-size: 24px;
					width: 40px;
					height: 40px;
					line-height: 40px;
					display: inline-block;
					text-align: center;
					border-radius: 50%;
					border: 1px solid #ccc;
					margin-left: 10px;
					margin-top: 22px;
					color: inherit;
					opacity: 0.75;
				}

					.footer-clean .item.social > a:hover {
						opacity: 0.9;
					}

			.footer-clean .copyright {
				margin-top: 14px;
				margin-bottom: 0;
				font-size: 13px;
				opacity: 0.6;
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0e3f66819e8cce0fe48d7a87129be3ba3fa53e447723", async() => {
                WriteLiteral("\r\n\t<div class=\"topnav\" id=\"myTopnav\">\r\n\t\t<a href=\"/Home/Index\" class=\"active\">VOVINAM</a>\r\n\t\t<a href=\"/Account/Login\">Logout (");
#nullable restore
#line 211 "C:\Users\Admin\Downloads\VovinamScoreManagerFix\VovinamScoreManager\VovinamScoreManagerWeb\Views\Manager\ManagerRank.cshtml"
                                    Write(ViewBag.userName);

#line default
#line hidden
#nullable disable
                WriteLiteral(")</a>\r\n");
#nullable restore
#line 212 "C:\Users\Admin\Downloads\VovinamScoreManagerFix\VovinamScoreManager\VovinamScoreManagerWeb\Views\Manager\ManagerRank.cshtml"
         if (ViewBag.chucvu == "-1")
		{

#line default
#line hidden
#nullable disable
                WriteLiteral("\t\t\t<a href=\"/Manager/ManagerRank\">Quản lý bậc </a>\r\n\t\t\t<a href=\"/Manager/ManagerStudent\">Quản lý học viên  </a>\r\n\t\t\t<a href=\"/Manager/ManagerClass\">Quản lý lớp học  </a>\r\n\t\t\t<a href=\"/Manager/SettingClass\">Thiết lập lớp học </a>\r\n");
#nullable restore
#line 218 "C:\Users\Admin\Downloads\VovinamScoreManagerFix\VovinamScoreManager\VovinamScoreManagerWeb\Views\Manager\ManagerRank.cshtml"
		}

#line default
#line hidden
#nullable disable
#nullable restore
#line 219 "C:\Users\Admin\Downloads\VovinamScoreManagerFix\VovinamScoreManager\VovinamScoreManagerWeb\Views\Manager\ManagerRank.cshtml"
         if (ViewBag.chucvu == "0")
		{

#line default
#line hidden
#nullable disable
                WriteLiteral("\t\t\t<a href=\"/Manager/ManagerScore\">Quản lý điểm </a>\r\n\t\t\t<a href=\"/Manager/ViewRank\">Xem bậc học viên</a>\r\n");
#nullable restore
#line 223 "C:\Users\Admin\Downloads\VovinamScoreManagerFix\VovinamScoreManager\VovinamScoreManagerWeb\Views\Manager\ManagerRank.cshtml"
		}

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n\t</div>\r\n\t<div class=\"login-page\">\r\n\r\n\t\t<h1 style=\"color:red;\">");
#nullable restore
#line 228 "C:\Users\Admin\Downloads\VovinamScoreManagerFix\VovinamScoreManager\VovinamScoreManagerWeb\Views\Manager\ManagerRank.cshtml"
                          Write(ViewBag.mess);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"</h1>
		<div class=""form"">
			<h2 style=""margin: auto;"">Quản lý bậc</h2>

			<div style=""text-align: center; display:flex;"">
				<div>
					<form action=""/Manager/InsertRank"" method=""post"">
						<table>
							<tr>
								<td>
									Tên bậc
								</td>
								<td>
									 <input  required type=""text"" name=""txtName"" />
								</td>

							</tr>
							<tr>
								<td>
									Điểm từ
								</td>
								<td>
									 <input  required type=""number"" name=""nmLimit"" />

								</td>

							</tr>
							<tr>
								<td>
									Điểm đến
								</td>
								<td>
									 <input  required type=""number"" name=""nmMax"" />

								</td>

							</tr>
							<tr>
								<td>
									Ảnh bậc
								</td>
								<td>
									 <input  required type=""text"" name=""txtImage"" />
								</td>

							</tr>
						</table>
						<button style=""color:green;"">Thêm mới</button>
					</form>
				</div>
				<div style=""width:10px;""></div>
				<div style=""wid");
                WriteLiteral("th:800px;\">\r\n\t\t\t\t\t<table border=\"1\">\r\n");
#nullable restore
#line 281 "C:\Users\Admin\Downloads\VovinamScoreManagerFix\VovinamScoreManager\VovinamScoreManagerWeb\Views\Manager\ManagerRank.cshtml"
                          
							foreach (var item in ViewBag.ListRank)
							{

#line default
#line hidden
#nullable disable
                WriteLiteral("\t\t\t\t\t\t\t\t\t\t<tr>\r\n\t\t\t\t\t\t\t\t\t\t\t<td>\r\n\t\t\t\t\t\t\t\t\t\t\t\t<form action=\"/Manager/ModifyRank\" method=\"post\">\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t<div style=\"display:flex;\">\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t<div>\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\tTên bậc\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t<br>\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t <input  required type=\"text\"");
                BeginWriteAttribute("value", " value=\"", 5882, "\"", 5900, 1);
#nullable restore
#line 291 "C:\Users\Admin\Downloads\VovinamScoreManagerFix\VovinamScoreManager\VovinamScoreManagerWeb\Views\Manager\ManagerRank.cshtml"
WriteAttributeValue("", 5890, item.Name, 5890, 10, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" name=\"txtName\" />\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t <input  required type=\"text\"");
                BeginWriteAttribute("value", " value=\"", 5965, "\"", 5981, 1);
#nullable restore
#line 292 "C:\Users\Admin\Downloads\VovinamScoreManagerFix\VovinamScoreManager\VovinamScoreManagerWeb\Views\Manager\ManagerRank.cshtml"
WriteAttributeValue("", 5973, item.Id, 5973, 8, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" name=\"hidID\" hidden />\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t<div style=\"width:5px;\"></div>\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t<div>\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\tĐiểm từ\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t<br>\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t <input  required type=\"number\"");
                BeginWriteAttribute("value", " value=\"", 6187, "\"", 6211, 1);
#nullable restore
#line 298 "C:\Users\Admin\Downloads\VovinamScoreManagerFix\VovinamScoreManager\VovinamScoreManagerWeb\Views\Manager\ManagerRank.cshtml"
WriteAttributeValue("", 6195, item.LimitScore, 6195, 16, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" name=\"nmLimit\" />\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t<div style=\"width:5px;\"></div>\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t<div>\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\tĐiểm đến\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t<br>\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t <input  required type=\"number\"");
                BeginWriteAttribute("value", " value=\"", 6413, "\"", 6435, 1);
#nullable restore
#line 304 "C:\Users\Admin\Downloads\VovinamScoreManagerFix\VovinamScoreManager\VovinamScoreManagerWeb\Views\Manager\ManagerRank.cshtml"
WriteAttributeValue("", 6421, item.MaxScore, 6421, 14, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" name=\"nmMax\" />\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t<div style=\"width:5px;\"></div>\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t<div>\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\tLink ảnh\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t<br>\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t <input  required type=\"text\"");
                BeginWriteAttribute("value", " value=\"", 6633, "\"", 6652, 1);
#nullable restore
#line 310 "C:\Users\Admin\Downloads\VovinamScoreManagerFix\VovinamScoreManager\VovinamScoreManagerWeb\Views\Manager\ManagerRank.cshtml"
WriteAttributeValue("", 6641, item.Image, 6641, 11, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" name=\"txtImage\" />\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t<div style=\"width:5px;\"></div>\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t<div>\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t<br>\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t<img");
                BeginWriteAttribute("src", " src=\"", 6820, "\"", 6837, 1);
#nullable restore
#line 316 "C:\Users\Admin\Downloads\VovinamScoreManagerFix\VovinamScoreManager\VovinamScoreManagerWeb\Views\Manager\ManagerRank.cshtml"
WriteAttributeValue("", 6826, item.Image, 6826, 11, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" style=""height:50px; width:150px;"" />
														</div>
														<div style=""width:5px;""></div>
														<div style=""display:flex"">
															<button name=""btn"" value=""1"" style=""color:red;"">Xóa</button>
															<button name=""btn"" value=""2"" style=""color:green;"">Lưu</button>
														</div>
													</div>
												</form>
											</td>
										</tr>
");
#nullable restore
#line 327 "C:\Users\Admin\Downloads\VovinamScoreManagerFix\VovinamScoreManager\VovinamScoreManagerWeb\Views\Manager\ManagerRank.cshtml"
							}

						

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
					</table>

				</div>


			</div>

		</div>

	</div>


	<footer>
		<div class=""container"">
			<div class=""row justify-content-center"">
				<div class=""col-lg-3 item social"" style=""display:flex;"">
				</div>
			</div>
		</div>
	</footer>
");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</html>\r\n\r\n<script src=\"https://cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js\"></script>\r\n<script src=\"https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/4.1.3/js/bootstrap.bundle.min.js\"></script>\r\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
