#pragma checksum "f:\Диплом\NewElcom\Elcom\Views\Home\Main.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5fd102ce5bd6aae5bf7e275fa9d06b9ce87f38af"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Main), @"mvc.1.0.view", @"/Views/Home/Main.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Main.cshtml", typeof(AspNetCore.Views_Home_Main))]
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
#line 1 "f:\Диплом\NewElcom\Elcom\Views\_ViewImports.cshtml"
using Elcom;

#line default
#line hidden
#line 2 "f:\Диплом\NewElcom\Elcom\Views\_ViewImports.cshtml"
using Elcom.Models;

#line default
#line hidden
#line 1 "f:\Диплом\NewElcom\Elcom\Views\Home\Main.cshtml"
using System.Data;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5fd102ce5bd6aae5bf7e275fa9d06b9ce87f38af", @"/Views/Home/Main.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d596a95d4a3b676f547551363826836a2c5ce762", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Main : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<System.Data.DataTable>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(50, 406, true);
            WriteLiteral(@"    <div class=""container-fluid"">
        <div class=""row"">
            <div class=""col-2"">
                <div class=""container-fluid"">
                    <div class=""row"">
                        <div class=""col workingSubject"">
                            <h6>Выберите лист:</h6>
                        </div>
                    </div>
                    <div class=""workingFieldLittle"">
");
            EndContext();
#line 13 "f:\Диплом\NewElcom\Elcom\Views\Home\Main.cshtml"
                         foreach (DataRow row in @Model.Rows)
                        {

#line default
#line hidden
            BeginContext(546, 149, true);
            WriteLiteral("                        <div class=\"row\">\r\n                            <div class=\"col\">\r\n                                <a class=\"subject\" href=\"#\"");
            EndContext();
            BeginWriteAttribute("onclick", " onclick=\"", 695, "\"", 726, 3);
            WriteAttributeValue("", 705, "ShowSheet(\'", 705, 11, true);
#line 17 "f:\Диплом\NewElcom\Elcom\Views\Home\Main.cshtml"
WriteAttributeValue("", 716, row[4], 716, 7, false);

#line default
#line hidden
            WriteAttributeValue("", 723, "\');", 723, 3, true);
            EndWriteAttribute();
            BeginContext(727, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(729, 6, false);
#line 17 "f:\Диплом\NewElcom\Elcom\Views\Home\Main.cshtml"
                                                                                       Write(row[0]);

#line default
#line hidden
            EndContext();
            BeginContext(735, 74, true);
            WriteLiteral("</a>\r\n                            </div>\r\n                        </div>\r\n");
            EndContext();
#line 20 "f:\Диплом\NewElcom\Elcom\Views\Home\Main.cshtml"
                        }

#line default
#line hidden
            BeginContext(836, 24, true);
            WriteLiteral("                        ");
            EndContext();
            BeginContext(2633, 311, true);
            WriteLiteral(@"
                    </div>
                    <div class=""row"">
                        <div class=""col workingSubject"" id=""caption"">
                            <h6>Выберите действие:</h6>
                        </div>
                    </div>
                    <div class=""workingFieldLittle"">
");
            EndContext();
#line 42 "f:\Диплом\NewElcom\Elcom\Views\Home\Main.cshtml"
                         foreach (DataRow row in @Model.Rows)
                            {

#line default
#line hidden
            BeginContext(3038, 28, true);
            WriteLiteral("                        <div");
            EndContext();
            BeginWriteAttribute("id", " id=\"", 3066, "\"", 3078, 1);
#line 44 "f:\Диплом\NewElcom\Elcom\Views\Home\Main.cshtml"
WriteAttributeValue("", 3071, row[4], 3071, 7, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(3079, 37, true);
            WriteLiteral(" class=\"Sheets\" style=\"display:none\">");
            EndContext();
            BeginContext(3117, 27, false);
#line 44 "f:\Диплом\NewElcom\Elcom\Views\Home\Main.cshtml"
                                                                         Write(Html.Partial("_" + @row[4]));

#line default
#line hidden
            EndContext();
            BeginContext(3144, 8, true);
            WriteLiteral("</div>\r\n");
            EndContext();
#line 45 "f:\Диплом\NewElcom\Elcom\Views\Home\Main.cshtml"
                            }

#line default
#line hidden
            BeginContext(3183, 28, true);
            WriteLiteral("                    </div>\r\n");
            EndContext();
            BeginContext(4548, 7687, true);
            WriteLiteral(@"                </div>
            </div>
            <div class=""col-10"">
                <div class=""container-fluid"">
                    <div class=""row"">
                        <div id=""TargetTable"" class=""col workingField"" style=""display: block;"">
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class=""modal fade"" id=""exampleModalLong"" tabindex=""-1"" role=""dialog"" aria-labelledby=""instructionTitle"" aria-hidden=""true"">
            <div class=""modal-dialog modal-dialog-centered modal-lg"" role=""document"">
                <div class=""modal-content"">
                    <div class=""modal-header"">
                        <h5 class=""modal-title"" id=""instructionTitle"">Инструкция к CMacros</h5>
                        <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                            <span aria-hidden=""true"">&times;</span>
                        </button>
                    </");
            WriteLiteral(@"div>
                    <div class=""modal-body"">
                        <div class=""container-fluid"">
                            <div class=""row"">
                                <div class=""col-3 list-group instructionField"" id=""instruction"">
                                    <a class=""list-group-item list-group-item-action"" href=""#list-item-1"">Задерживается ЗП</a>
                                    <a class=""list-group-item list-group-item-action"" href=""#list-item-2"">Задерживается ЗК</a>
                                    <a class=""list-group-item list-group-item-action"" href=""#list-item-3"">Приемка</a>
                                    <a class=""list-group-item list-group-item-action"" href=""#list-item-4"">Дефицит под ЗК</a>
                                    <a class=""list-group-item list-group-item-action"" href=""#list-item-5"">ГТД</a>
                                    <a class=""list-group-item list-group-item-action"" href=""#list-item-6"">Отказы по ЗК</a>
                                ");
            WriteLiteral(@"    <a class=""list-group-item list-group-item-action"" href=""#list-item-7"">KPI МЗ</a>
                                    <a class=""list-group-item list-group-item-action"" href=""#list-item-8"">Отгрузка от поставщика</a>
                                </div>
                                <div data-spy=""scroll"" data-target=""#instruction"" data-offset=""0"" class=""col-9 scrollspy-example instructionField"">

                                    <h6 id=""list-item-1"">Задерживается ЗК</h6>
                                    <p class=""instructionText"">Нажмите ""Обновить"". Выгрузятся все задерживающиеся позиции. Внимание! Если в столбце ""Дни задержки"" указано ""Обновите сроки ЗК"", это означает, что по данной строке не были обновлены дни задержки, и отправить письмо МП нельзя. Для того, чтобы эта позиция стала доступной для отпраки письма МП, обновите сроки в Макономи и еще раз выгрузите данные в макросе.<br>Если Вы не можете ускорить поставку задерживающейся позиции, то  для отправки письма МП в столбце ""Решение по ");
            WriteLiteral(@"позиции"" выберите значение ""Отправить запрос МП"". Нажмите ""Отправить запрос МП"". В столбце ""Ваш запрос"" можно увидеть результат отправки письма. В случае успешной загрузки данных в Maconomy появится отметка ""Отправлен"" в исходной строке. Если запрос отправлен не был, необходимо повторно выбрать ""Отправить запрос МП"".<br>Для выгрузки отчета в xlsx используйте кнопку ""Выгрузить в xslx"".</p>

                                    <h6 id=""list-item-2"" class="""">Задерживается ЗП</h6>
                                    <p class=""instructionText"">Выберите склад и нажмите ""Выгрузить"". На странице появятся данные по задерживающимся позициям, у которых ожидаемая дата прихода раньше раньше сегодняшнего дня.<br>Для выгрузки отчета в xlsx используйте кнопку ""Выгрузить в xslx"".</p>

                                    <h6 id=""list-item-3"">Приемка</h6>
                                    <p class=""instructionText"">Выберите склад и нажмите ""Обновить"". На странице появятся данные о товарах на приходе по выбранному складу.");
            WriteLiteral(@"<br>Для выгрузки отчета в xlsx используйте кнопку ""Выгрузить в xslx"".</p>

                                    <h6 id=""list-item-4"">Дефицит под ЗК</h6>
                                    <p class=""instructionText"">Отчет выдает информацию о недостающих товарах под заказы клиентов, под которые еще не созданы заказы поставщикам.<br>Нажмите ""Обновить"". На странице появятся недостающие позиции под заказы клиентов. По выгруженным номерам поставщиков нужно собрать заказы поставщикам под заказы клиентов. Как только заказы поставщикам будут созданы, данные позиции не отобразятся при повторной выгрузке.<br>Для выгрузки отчета в xlsx используйте кнопку ""Выгрузить в xslx"".</p>

                                    <h6 id=""list-item-5"">ГТД</h6>
                                    <p class=""instructionText"">Отчет выдает информацию о партиях товара, когда-либо оприходованных на складе.<br>Введите номер товара в поле ввода (это поле обязательно для заполнения!), а также заполните другие фильтры (можно устаналивать усло");
            WriteLiteral(@"вие на одну из границ даты создания партии!), далее выберите ""Выгрузить"". В появившейся фрме введите нужные фильтры и нажмите ОК.<br>Для выгрузки отчета в xlsx используйте кнопку ""Выгрузить в xslx"".</p>

                                    <h6 id=""list-item-6"">Отказы по ЗК</h6>
                                    <p class=""instructionText"">Отчет выдает информацию по обнулениям и отказам от позиций из за срыва сроков в ЗК. Выгружаются только необработанные позиции.<br>Нажмите ""Выгрузить"". На странице появятся все необработанные обнуления и отказы от позиций, по которым требуется вмешательство МЗ.<br>Для выгрузки отчета в xlsx используйте кнопку ""Выгрузить в xslx"".</p>

                                    <h6 id=""list-item-7"">KPI МЗ</h6>
                                    <p class=""instructionText"">В окне ""Работа с листом"" выберите необходимые параметры и нажмите ""Выгрузить"".<br>Для выгрузки отчета в xlsx используйте кнопку ""Выгрузить в xslx"".</p>

                                    <h6 id=""list-item-");
            WriteLiteral(@"8"">Отгрузка от поставщика</h6>
                                    <p class=""instructionText"">В окне ""Работа с листом"" выберите необходимые параметры и нажмите ""Выгрузить"".<br>Для выгрузки отчета в xlsx используйте кнопку ""Выгрузить в xslx"".</p>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class=""modal-footer"">
                        <button type=""button"" class=""btn btn-outline-primary"" data-dismiss=""modal"">ОК</button>
                    </div>
                </div>
            </div>
        </div>
        <div id=""LoadingModal"" class=""modal"" tabindex=""-1"" role=""dialog"" display=""none"">
            <div class=""modal-dialog modal-dialog-centered modal-lg"" role=""document"">
                <div class=""modal-content"">
                    <div class=""modal-header"">
                        <h4 class=""modal-title"">Происходит загрузка данных</h4>
                    </div>
             ");
            WriteLiteral(@"       <div class=""modal-body"">
                        Пожалуйста, подождите
                    </div>
                </div>
            </div>
        </div>
    </div>
<script>
    var CurrentSheet = ""Dates"";
    function ShowSheet(sheetName) {
        try {
            document.getElementById(CurrentSheet).style.display = ""none"";
        }
        catch (e) {
        }
        document.getElementById(sheetName).style.display = ""block"";
        CurrentSheet = sheetName;
        }
</script>
");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<System.Data.DataTable> Html { get; private set; }
    }
}
#pragma warning restore 1591
