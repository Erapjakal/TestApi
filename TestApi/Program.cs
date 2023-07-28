using ClosedXML.Graphics;
using DocumentFormat.OpenXml.ExtendedProperties;
using DocumentFormat.OpenXml.Office2010.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using Newtonsoft.Json;
using NPOI.SS.Formula.Functions;
using OfficeOpenXml;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json.Serialization;

namespace TestApi
{
    internal class Program
    {
        #region API
        private static HttpClient? client;
        #endregion        

        #region readOnlyes
        private static readonly string PERFECTUMAPIKEY = "82c6d13ac58036e4db231650e8f6bea5";
        private static readonly string DOMAIN_PERFECTUM = "https://mostit.perfectum.cloud/";
        private static readonly string DOMAIN_USPACY = "https://api.most-it.uspacy.ua";
        private static readonly string _filePathFirst = "readyToImport1.xlsx";
        private static readonly string _filePathSecond = "readyToImport2.xlsx";
        private static readonly string _filePathResult = "readyToImportResult.xlsx";
        #endregion

        #region Адреса пароли явки
        public static string ApiSuffix { get; set; } = "";
        public static string PerfectumApiSuffix { get; set; } = "";
        #endregion

        static async Task Main(string[] args)
        {
            #region HttpClientInit

            #region httpClient
            HttpClientHandler handler = new HttpClientHandler();
            //ignore sertificate
            handler.ServerCertificateCustomValidationCallback = IgnoreCertificateValidation;

            client = new HttpClient(handler);
            //httpclient
            ApiSuffix = "https://most-it.uspacy.ua/auth/v1/auth/sign_in/";
            var httpResponse = await client.PostAsync(ApiSuffix, LoginCred());

            var responseStr = httpResponse.Content.ReadAsStringAsync().Result;
            //чтение ответа и конвертация в структуру TokenResponse
            var token = JsonConvert.DeserializeObject<Library.TokenResponse>(responseStr);

            //подставляем апи ключ для последующих авторизаций
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token?.Jwt);
            #endregion

            #endregion

            #region Загрузка данных из Uspacy   

            #region Stuff proccesor
            //https://{domain}.uspacy.ua/company/v1/users/
            ApiSuffix = "/company/v1/users/";
            Library.Stuff uspacyStuff = new();
            foreach (var data_line in GetLines(ApiSuffix))
            {
                uspacyStuff = JsonConvert.DeserializeObject<Library.Stuff>(data_line);
                Console.WriteLine("Загрузка Stuff завершена успешно");
            }
            //foreach (var staf in uspacyStuff.Data)
            //{
            //    Console.WriteLine("ID - " + staf.Id + " LastName - " + staf.LastName);
            //}
            #endregion

            /*#region Entity proccesor
            //https://{domain}.uspacy.ua/crm/v1/entity/
            ApiSuffix = "/crm/v1/entity/";
            Uspacy.Entities uspacyEntities = new();
            foreach (var data_line in GetLines(ApiSuffix))
            {
                uspacyEntities = JsonConvert.DeserializeObject<Uspacy.Entities>(data_line);
                Console.WriteLine("Загрузка Entity завершена успешно");
            }
            foreach (var item in uspacyEntities.Data)
            {
                Console.WriteLine("Title - " + item.Title + " * " + "Type - " + item.Type + " * " + "Table Name - " + item.TableName + " * " + "Sort - " + item.Sort);
            }
            #endregion*/

            /*#region Comments
            //https://{domain}.uspacy.ua/comments/v1/comments/
            ApiSuffix = "/comments/v1/comments/?entityType=comment&entityId=1";
            Uspacy.Comments uspacyComments = new();
            foreach (var data_line in GetLines(ApiSuffix))
            {
                uspacyComments = JsonConvert.DeserializeObject<Uspacy.Comments>(data_line);
                Console.WriteLine("Загрузка Entity завершена успешно");
            }
            foreach (var item in uspacyComments.Data)
            {
                Console.WriteLine(item.Id + " - " + item.Message + " - " + item.Date + " - " + item.AuthorId + " - " + item.EntityType + " - " + item.Reactions);
            }
            #endregion*/

            /*#region Field types
            //https://{domain}.uspacy.ua/crm/v1/field_types/
            ApiSuffix = "/crm/v1/field_types/";
            //Library.FieldType uspacyFieldTypes = new();
            foreach (var data_line in GetLines(ApiSuffix))
            {
                //uspacyFieldTypes = JsonConvert.DeserializeObject<Library.FieldType>(data_line);
                Console.WriteLine("Загрузка Field types завершена успешно");
            }
            #endregion*/

            /*#region Field types by code
            //https://{domain}.uspacy.ua/crm/v1/entities/{entity}/fields/{field}/
            ApiSuffix = $"/crm/v1/entities/{uspacyEntity.data[0]}/fields/{uspacyFieldTypes.data[0]}/";
            foreach (var data_line in GetLines(ApiSuffix))
            {                
                Console.WriteLine("Загрузка Field type by code завершена успешно");
            }
            #endregion*/

            /*#region Elements list
            //https://{domain}.uspacy.ua/crm/v1/entities/{entity}/lists/{field}/
            ApiSuffix = $"/crm/v1/entities/{uspacyEntity.data[0]}/lists/{uspacyFieldTypes.data[0]}/";
            //Library.FieldType uspacyFieldTypes = new();
            foreach (var data_line in GetLines(ApiSuffix))
            {
                //uspacyFieldTypes = JsonConvert.DeserializeObject<Library.FieldType>(data_line);
                Console.WriteLine("Загрузка Elemet list завершена успешно");
            }
            #endregion*/

            /*#region Entity Items
            //https://{domain}.uspacy.ua/crm/v1/entities/{entity}/
            ApiSuffix = $"/crm/v1/entities/{uspacyEntities.Data.First()}/";
            Uspacy.Root uspacyEntityList = new();
            foreach (var data_line in GetLines(ApiSuffix))
            {
                uspacyEntityList = JsonConvert.DeserializeObject<Uspacy.Root>(data_line);
                Console.WriteLine("Загрузка Entity items завершена успешно");
            }
            #endregion*/
            
            #region Company proccesor
            // https://api.most-it.uspacy.ua/crm/v1/entities/companies/?page=1&list=500
            ApiSuffix = "/crm/v1/entities/companies/?page=485&list=5";
            Library.Company uspacyCompany = new();
            foreach (var data_line in GetLines(ApiSuffix))
            {
                uspacyCompany = JsonConvert.DeserializeObject<Library.Company>(data_line);
                Console.WriteLine("Загрузка Company завершена успешно");
            }
            #endregion

            /*foreach (var item in uspacyCompany.Data)
            {
                await Console.Out.WriteLineAsync("CreatedBy - " + item.CreatedBy.ToString() + "ChangedBy - " + item.ChangedBy.ToString() + " " + "Owner - " + item.Owner);
            }
            Console.ReadLine();*/
            /*foreach (var uCom in uspacyCompany.Data)
            {
                var uComContanct = uCom.Contacts;
                if (uComContanct != null)
                {
                    foreach (var item in uComContanct)
                    {
                        Console.WriteLine("ID - " + item?.Id + " Title - " + item?.Title);

                        if (item?.Email?.FirstOrDefault()?.Value != null)
                        {
                            Console.WriteLine("Email - " + item.Email.FirstOrDefault().Value);
                        }
                        else
                        {
                            Console.WriteLine("Email - No email");
                        }

                        if (item?.Phone?.FirstOrDefault()?.Value != null)
                        {
                            Console.WriteLine("Phone - " + item.Phone.FirstOrDefault().Value);
                        }
                        else
                        {
                            Console.WriteLine("Phone - No phone");
                        }
                    }
                }

            }
            Console.ReadLine();*/

            /*#region Contact proccesor
            //https://{domain}.uspacy.ua/crm/v1/entities/contacts/
            ApiSuffix = "/crm/v1/entities/contacts/?page=1&list=2";
            ContactUspacy uspacyContact = new();
            foreach (var data_line in GetLines(ApiSuffix))
            {
                uspacyContact = JsonConvert.DeserializeObject<ContactUspacy>(data_line);
                Console.WriteLine("Загрузка Contacts завершена успешно");
            }
            AddContactToPerfect(uspacyContact);
            #endregion*/

            /*#region Deal proccesor
            //https://{domain}.uspacy.ua/crm/v1/entities/deals/
            ApiSuffix = "/crm/v1/entities/deals/?list=20";
            Library.Deal uspacyDeals = new();
            foreach (var data_line in GetLines(ApiSuffix))
            {
                uspacyDeals = JsonConvert.DeserializeObject<Library.Deal>(data_line);
                Console.WriteLine("Загрузка Deals завершена успешно");
            }
            #endregion*/

            /*#region Lead proccesor
            //https://{domain}.uspacy.ua/crm/v1/entities/leads/
            ApiSuffix = "/crm/v1/entities/leads/?list=20";
            Library.Lead uspacyLead = new();
            foreach (var data_line in GetLines(ApiSuffix))
            {
                uspacyLead = JsonConvert.DeserializeObject<Library.Lead>(data_line);
                Console.WriteLine("Загрузка Lead завершена успешно");
            }
            #endregion*/

            /*#region CRM Entity item
            //https://{domain}.uspacy.ua/crm/v1/entities/{entity}/{itemId}/
            ApiSuffix = "/crm/v1/entities/{entity}/{itemId}/";
            //Library.FieldType uspacyCRMEntityItem = new();
            foreach (var data_line in GetLines(ApiSuffix))
            {
                //uspacyCRMEntityItem = JsonConvert.DeserializeObject<Library.FieldType>(data_line);
                Console.WriteLine("Загрузка CRM Entity item завершена успешно");
            }
            #endregion*/

            /*#region Avalibale CRM Task
            //https://{domain}.uspacy.ua/crm/v1/static/tasks/
            ApiSuffix = "/crm/v1/static/tasks/";
            Library.TaskRoot uspacyAvaliableTask = new();
            foreach (var data_line in GetLines(ApiSuffix))
            {
                uspacyAvaliableTask = JsonConvert.DeserializeObject<Library.TaskRoot>(data_line);
                Console.WriteLine("Загрузка Avalibale CRM Task завершена успешно");
            }
            #endregion*/

            /*#region  CRM Task by ID
            //https://{domain}.uspacy.ua/crm/v1/static/task/{itemId}/
            ApiSuffix = "/crm/v1/static/task/{itemId}/";
            //Library.FieldType uspacyAvaliableTask = new();
            foreach (var data_line in GetLines(ApiSuffix))
            {
                //uspacyAvaliableTask = JsonConvert.DeserializeObject<Library.FieldType>(data_line);
                Console.WriteLine("Загрузка CRM Task by ID завершена успешно");
            }
            #endregion*/

            /*#region Funnel
            //https://{domain}.uspacy.ua/crm/v1/entities/{entity}/funnel
            ApiSuffix = "/crm/v1/entities/{entity}/funnel";
            //Library.FieldType uspacyAvaliableTask = new();
            foreach (var data_line in GetLines(ApiSuffix))
            {
                //uspacyAvaliableTask = JsonConvert.DeserializeObject<Library.FieldType>(data_line);
                Console.WriteLine("Загрузка Funnel завершена успешно");
            }
            #endregion*/

            /*#region Funnel by ID
            //https://{domain}.uspacy.ua/crm/v1/entities/{entity}/funnel/{funnelId}
            ApiSuffix = "/crm/v1/entities/{entity}/funnel/{funnelId}";
            //Library.FieldType uspacyAvaliableTask = new();
            foreach (var data_line in GetLines(ApiSuffix))
            {
                //uspacyAvaliableTask = JsonConvert.DeserializeObject<Library.FieldType>(data_line);
                Console.WriteLine("Загрузка Funnel by ID завершена успешно");
            }
            #endregion*/

            /*#region Canban stages
            //https://{domain}.uspacy.ua/crm/v1/entities/{entity}/kanban/stage
            ApiSuffix = "/crm/v1/entities/{entity}/kanban/stage";
            //Library.FieldType uspacyAvaliableTask = new();
            foreach (var data_line in GetLines(ApiSuffix))
            {
                //uspacyAvaliableTask = JsonConvert.DeserializeObject<Library.FieldType>(data_line);
                Console.WriteLine("Загрузка Canban stages завершена успешно");
            }
            #endregion*/

            /*#region Canban stages by ID
            //https://{domain}.uspacy.ua/crm/v1/entities/{entity}/kanban/stage/{stageId}
            ApiSuffix = "/crm/v1/entities/{entity}/kanban/stage/{stageId}";
            //Library.FieldType uspacyAvaliableTask = new();
            foreach (var data_line in GetLines(ApiSuffix))
            {
                //uspacyAvaliableTask = JsonConvert.DeserializeObject<Library.FieldType>(data_line);
                Console.WriteLine("Загрузка Canban stages by ID завершена успешно");
            }


            #endregion*/

            /*#region Calls
            //https://{domain}.uspacy.ua/crm/v1/events/call
            ApiSuffix = "/crm/v1/events/call?list=20";
            Library.Call uspacyCalls = new();
            foreach (var data_line in GetLines(ApiSuffix))
            {
                uspacyCalls = JsonConvert.DeserializeObject<Library.Call>(data_line);
                Console.WriteLine("Загрузка Calls завершена успешно");
            }
            #endregion*/

            #endregion

            #region Import to Perfectum 
            //PerfectumGetClient();
            var perfectStaffs = PerfectumGetStaff();
            var pManagers = JsonConvert.DeserializeObject<Perfectum.Stuff>(perfectStaffs);
            PerfectumAddClient(uspacyCompany, uspacyStuff, pManagers);
            /*foreach (var pStaf in pManagers.Data)
            {
                Console.WriteLine("ID - " + pStaf.Staffid + " LastName - " + pStaf.Lastname);
            }*/
            PerfectumAddClient(uspacyCompany, uspacyStuff, pManagers);
            //PerfectumAddClientContact(uspacyContact);

            

            #region Test Perfectu Client Import 
            //PerfectumAddClient(uspacyCompany); 
            #endregion

            #endregion

            /*#region EXcel

            #region Excel file creation
            // Создание нового файла Excel
            string filePath = "readyToImport.xlsx";
            FileInfo file = new FileInfo(filePath);
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (ExcelPackage package = new ExcelPackage(file))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Contacts");

                // Запись заголовков столбцов
                string[] headers = {
                "Імʼя контакту", "Прізвище контакту", "По батькові", "Email", "Додаткові email",
                "Телефон контакту", "Додаткові номери телефонів", "Посада", "Стать", "Останні зміни",
                "Компанія", "Телефон", "Країна", "Місто", "Індекс", "Область", "Адреса", "Сайт",
                "import_date_status_changed", "Вулиця (юр. адреса)", "Місто (юр. адреса)",
                "Область (юр. адреса)", "Індекс (юр. адреса)", "Країна (юр. адреса)",
                "Вулиця (фіз. адреса)", "Місто (фіз. адреса)", "Область (фіз. адреса)",
                "Індекс (фіз. адреса)", "Країна (фіз. адреса)", "Довгота", "Широта", "Останні зміни",
                "Категорія", "Дисконтна група клієнта", "Основний менеджер", "import_is_provider",
                "Персональний менеджер", "тип клиента", "сфера деятельности",
                "обобщенная информация о компании", "ссылка", "Дополнительные контакты",
                "Р/с №", "Должность", "подписант", "МФО Банка", "ЕГРПОУ", "ИНН",
                "Дані про керівника в особі", "Email для Вчасно"
            };

                for (int i = 0; i < headers.Length; i++)
                {
                    worksheet.Cells[1, i + 1].Value = headers[i];
                }

                // Запись данных контактов
                for (int i = 0; i < users.Count; i++)
                {
                    var contact = users[i];
                    worksheet.Cells[i + 2, 1].Value = contact.FirstName;
                    worksheet.Cells[i + 2, 2].Value = contact.LastName;
                    worksheet.Cells[i + 2, 3].Value = contact.MiddleName;
                    worksheet.Cells[i + 2, 4].Value = contact.Email;
                    worksheet.Cells[i + 2, 5].Value = contact.AdditionalEmails;
                    worksheet.Cells[i + 2, 6].Value = contact.Phone;
                    worksheet.Cells[i + 2, 7].Value = contact.AdditionalPhones;
                    worksheet.Cells[i + 2, 8].Value = contact.Position;
                    worksheet.Cells[i + 2, 9].Value = contact.Gender;
                    worksheet.Cells[i + 2, 10].Value = contact.LastModified;
                    worksheet.Cells[i + 2, 11].Value = contact.Company;
                    worksheet.Cells[i + 2, 12].Value = contact.CompanyPhone;
                    worksheet.Cells[i + 2, 13].Value = contact.Country;
                    worksheet.Cells[i + 2, 14].Value = contact.City;
                    worksheet.Cells[i + 2, 15].Value = contact.PostalCode;
                    worksheet.Cells[i + 2, 16].Value = contact.Region;
                    worksheet.Cells[i + 2, 17].Value = contact.Address;
                    worksheet.Cells[i + 2, 18].Value = contact.Website;
                    worksheet.Cells[i + 2, 19].Value = contact.ImportDateStatusChanged;
                    worksheet.Cells[i + 2, 20].Value = contact.LegalAddressStreet;
                    worksheet.Cells[i + 2, 21].Value = contact.LegalAddressCity;
                    worksheet.Cells[i + 2, 22].Value = contact.LegalAddressRegion;
                    worksheet.Cells[i + 2, 23].Value = contact.LegalAddressPostalCode;
                    worksheet.Cells[i + 2, 24].Value = contact.LegalAddressCountry;
                    worksheet.Cells[i + 2, 25].Value = contact.PhysicalAddressStreet;
                    worksheet.Cells[i + 2, 26].Value = contact.PhysicalAddressCity;
                    worksheet.Cells[i + 2, 27].Value = contact.PhysicalAddressRegion;
                    worksheet.Cells[i + 2, 28].Value = contact.PhysicalAddressPostalCode;
                    worksheet.Cells[i + 2, 29].Value = contact.PhysicalAddressCountry;
                    worksheet.Cells[i + 2, 30].Value = contact.Longitude;
                    worksheet.Cells[i + 2, 31].Value = contact.Latitude;
                    worksheet.Cells[i + 2, 32].Value = contact.LastModified;
                    worksheet.Cells[i + 2, 33].Value = contact.Category;
                    worksheet.Cells[i + 2, 34].Value = contact.DiscountGroup;
                    worksheet.Cells[i + 2, 35].Value = contact.PrimaryManager;
                    worksheet.Cells[i + 2, 36].Value = contact.IsProvider;
                    worksheet.Cells[i + 2, 37].Value = contact.PersonalManager;
                    worksheet.Cells[i + 2, 38].Value = contact.ClientType;
                    worksheet.Cells[i + 2, 39].Value = contact.Industry;
                    worksheet.Cells[i + 2, 40].Value = contact.CompanyInfo;
                    worksheet.Cells[i + 2, 41].Value = contact.WebsiteLink;
                    worksheet.Cells[i + 2, 42].Value = contact.AdditionalContacts;
                    worksheet.Cells[i + 2, 43].Value = contact.AccountNumber;
                    worksheet.Cells[i + 2, 44].Value = contact.PositionRu;
                    worksheet.Cells[i + 2, 45].Value = contact.Signatory;
                    worksheet.Cells[i + 2, 46].Value = contact.BankMFO;
                    worksheet.Cells[i + 2, 47].Value = contact.TaxID;
                    worksheet.Cells[i + 2, 48].Value = contact.ExecutiveInfo;
                    worksheet.Cells[i + 2, 49].Value = contact.EmailForVchasno;
                }

                package.Save();
            }
            Console.WriteLine("Файл 'readyToImport.xlsx' создан и данные успешно записаны.");
            #endregion

            #region Склейка xlsx
            //TO DO проверь пути файлов
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            GlueXLSX();
            Console.WriteLine("Объединение файлов завершено.");
            #endregion

            #endregion*/

            Console.ReadLine();
        }

        #region Helpers

        #region API
        private static bool IgnoreCertificateValidation(HttpRequestMessage? request, X509Certificate2? certificate, X509Chain? chain, SslPolicyErrors sslPolicyErrors)
        {
            // Возвращаем true, чтобы принять любой сертификат без проверки
            return true;
        }
        #region perfectum
        private static async Task<string> PerfectumGetClient()
        {
            //https://{{domain}}/api/clients/contacts/{{client_id}}/{{contact_id}}
            //https://{{domain}}/api/clients/{{client_id}}
            PerfectumApiSuffix = "/api/clients/contacts/";
            var clientPerfect = new HttpClient();
            var requestPerfect = new HttpRequestMessage(HttpMethod.Get, DOMAIN_PERFECTUM + PerfectumApiSuffix + 165);
            requestPerfect.Headers.Add("APIKEY", PERFECTUMAPIKEY);
            var responsePerfect = await clientPerfect.SendAsync(requestPerfect);
            var test = responsePerfect.Content.ReadAsStringAsync().Result;
            return test;
        }
        private static async Task PerfectumAddClient(Library.Company uCompany, Library.Stuff uStuff, Perfectum.Stuff perfectStaffs)
        {

            foreach (var uC in uCompany.Data)
            {
                var firstName = "";
                var lastName = "";
                var patronymic = "";
                #region Formating text
                #region Phone
                var phoneNumbers = uC?.Phone?.Select(phone => phone.Value);
                var combinedPhoneNumbers = phoneNumbers != null ? string.Join(",", phoneNumbers) : " ";
                #endregion
                #region Email
                var emails = uC?.Email?.Select(e => e.Value);
                var combinedEmails = emails != null ? string.Join(",", emails) : " ";
                #endregion
                #region Adress
                string[] addressParts = uC?.Address.Split(",");
                var PhysicalAddressCountry = "";
                var PhysicalAddressPostalCode = "";
                var PhysicalAddressCity = "";
                var PhysicalAdressRegion = "";
                var PhysicalAddressStreet = "";
                if (!string.IsNullOrWhiteSpace(addressParts[0]))
                {
                    if (addressParts.Length > 5)
                    {
                        if (addressParts[0] != null)
                        {
                            PhysicalAddressCountry = addressParts[0].Trim();
                        }
                        if (addressParts[1] != null)
                        {
                            PhysicalAddressPostalCode = addressParts[1].Trim();
                        }
                        if (addressParts[2] != null)
                        {
                            PhysicalAdressRegion = addressParts[2].Trim();
                        }
                        if (addressParts[3] != null)
                        {
                            PhysicalAddressCity = addressParts[3].Trim();
                        }
                        if (addressParts[4] != null)
                        {
                            PhysicalAddressStreet = addressParts[4] + addressParts[5];
                        }
                    }
                    else
                    {
                        if (addressParts[0] != null)
                        {
                            PhysicalAddressCountry = addressParts[0].Trim();
                        }
                        if (addressParts[1] != null)
                        {
                            PhysicalAddressPostalCode = addressParts[1].Trim();
                        }
                        if (addressParts[2] != null)
                        {
                            PhysicalAddressCity = addressParts[2].Trim();
                        }
                        if (addressParts[3] != null)
                        {
                            PhysicalAddressStreet = addressParts[3] + addressParts[4];
                        }
                    }
                }
                else
                {
                    Console.WriteLine("No adress in " + uC.CompanyName);
                }
                #endregion
                #region Stuff
                var manager = new List<string>();
                manager = GetStuffId(uC, uStuff, perfectStaffs);
                #endregion
                #region Contacts
                if (uC.Contacts != null && uC.Contacts.Count > 0)
                {
                    var contact = uC.Contacts.FirstOrDefault();

                    if (contact != null)
                    {
                        var FIO = contact.Title.Split(" ");

                        firstName = FIO.ElementAtOrDefault(0)?.Trim();
                        lastName = FIO.ElementAtOrDefault(1)?.Trim();
                        patronymic = FIO.ElementAtOrDefault(2)?.Trim();
                    }
                }
                else 
                {
                    Console.WriteLine("no contact " + uC.CompanyName);
                }
                #endregion
                #endregion
                #region Initialize Client
                var pClient = new Perfectum.Client()
                {
                    Company = (uC?.CompanyName) ?? "",
                    Phonenumber = (uC?.Phone?.FirstOrDefault()?.Value) ?? "000",
                    Website = (uC?.Site) ?? "cauta.net",
                    City = (PhysicalAddressCity) ?? "-",
                    Country = (PhysicalAddressCountry) ?? "-",
                    Zip = (PhysicalAddressPostalCode) ?? "-",
                    Address = (PhysicalAddressStreet) ?? "-",
                    State = (PhysicalAdressRegion) ?? "-",
                    CustomerAdmins = manager                    
                };
                #endregion
                #region Import client 
                //https://{{domain}}/api/clients/
                PerfectumApiSuffix = "/api/clients/";
                var clientImport = new HttpClient();
                var requestImport = new HttpRequestMessage(HttpMethod.Post, DOMAIN_PERFECTUM + PerfectumApiSuffix);
                requestImport.Headers.Add("APIKEY", PERFECTUMAPIKEY);
                var content = new StringContent(JsonConvert.SerializeObject(pClient), Encoding.UTF8, "application/json");
                requestImport.Content = content;
                var responseImport = clientImport.SendAsync(requestImport).Result;
                Console.WriteLine("Добавляю клиента - " + pClient.Company);
                Console.WriteLine(responseImport.Content.ReadAsStringAsync().Result);
                var perfectClientID = JsonConvert.DeserializeObject<Perfectum.ResponseWhenClientWasAdded>(responseImport.Content.ReadAsStringAsync().Result);
                Thread.Sleep(TimeSpan.FromSeconds(2));
                TestContact(perfectClientID.Id, uC);
                Thread.Sleep(TimeSpan.FromSeconds(2));
                #endregion
            }
        }
        private static List<string> GetStuffId(Library.DatumCompany? uC, Library.Stuff uStuff, Perfectum.Stuff perfectStaffs)
        {
            var managerId = new List<string>();
            foreach (var item in uStuff.Data)
            {
                if (item.Id == uC?.Owner)
                {
                    managerId.Add(perfectStaffs.Data
                        .FirstOrDefault(pm =>
                        item.FirstName == pm.Firstname
                        &&
                        item.LastName.Replace(" new", "")
                        ==
                        pm.Lastname)?
                        .Staffid);
                }
            }
            return managerId;
        }
        private static async Task TestContact(int id, Library.DatumCompany uC)
        {
            if (uC.Contacts != null)
            {
                if (uC.Contacts.Count > 0)
                {
                    foreach (var contact in uC.Contacts)
                    {
                        #region Name cheking
                        var FIO = contact.Title.Split(" ");
                        string? firstName = FIO.ElementAtOrDefault(0)?.Trim();
                        string? lastName = FIO.ElementAtOrDefault(1)?.Trim();
                        string? patronymic = FIO.ElementAtOrDefault(2)?.Trim();
                        #endregion

                        #region Init Contact  
                        var contactToAdd = new Perfectum.ClientContactToConvert() { };
                        //var contactToAdd = new Perfectum.ClientContactToConvert()
                        //{
                        //    Userid = id.ToString(),
                        //    IsPrimary = "1",
                        //    Donotsendwelcomeemail = "1",
                        //    Firstname = (firstName) ?? "name",
                        //    Lastname = (lastName) ?? "lastName",
                        //    Patronymic = (patronymic) ?? "",
                        //    Phonenumber = (uC?.Phone?.FirstOrDefault()?.Value) ?? "000",
                        //    Email = (uC?.Email?.FirstOrDefault()?.Value) ?? "noemail@net.ua",
                        //    Title = (contact?.Title) ?? "",
                        //};
                        #endregion

                        #region Import contact
                        PerfectumApiSuffix = "/api/contacts";
                        var clientContact = new HttpClient();
                        var requestContact = new HttpRequestMessage(HttpMethod.Post, DOMAIN_PERFECTUM + PerfectumApiSuffix);
                        requestContact.Headers.Add("APIKEY", PERFECTUMAPIKEY);
                        var contentContact = new StringContent(JsonConvert.SerializeObject(contactToAdd));
                        requestContact.Content = contentContact;
                        var responseContact = await clientContact.SendAsync(requestContact);
                        Console.WriteLine("Добавляю контакт клиента - " + contactToAdd.Lastname);
                        Console.WriteLine(responseContact.Content.ReadAsStringAsync().Result);
                        Thread.Sleep(TimeSpan.FromSeconds(2));
                        #endregion
                    }
                }
            }
        }
        private static async Task PerfectumAddStuff(string contentPerfectum)
        {
            HttpClientHandler handler = new HttpClientHandler();
            //ignore sertificate
            handler.ServerCertificateCustomValidationCallback = IgnoreCertificateValidation;
            //https://{{domain}}/api/staff
            PerfectumApiSuffix = "api/staff";
            var clientPerfectum = new HttpClient(handler);
            var requestPerfectum = new HttpRequestMessage(HttpMethod.Post, DOMAIN_PERFECTUM + PerfectumApiSuffix);
            requestPerfectum.Headers.Add("APIKEY", PERFECTUMAPIKEY);
            var content = new StringContent(contentPerfectum);
            requestPerfectum.Content = content;
            var responsePerfectum = await clientPerfectum.SendAsync(requestPerfectum);
            //responsePerfectum.EnsureSuccessStatusCode();
            Console.WriteLine(await responsePerfectum.Content.ReadAsStringAsync());

        }
        private static string PerfectumGetStaff()
        {
            // https://{{domain}}/api/staff/{{staff_id}}?limit=3
            PerfectumApiSuffix = "/api/staff/";
            var clientstaff = new HttpClient();
            var requeststaff = new HttpRequestMessage(HttpMethod.Get, DOMAIN_PERFECTUM + PerfectumApiSuffix);
            requeststaff.Headers.Add("APIKEY", PERFECTUMAPIKEY);
            var responsestaff = clientstaff.SendAsync(requeststaff).Result;
            var json = responsestaff.Content.ReadAsStringAsync().Result;
            return json;
        }
        #endregion   

        private static StringContent LoginCred()
        {
            //var loginData = new
            //{
            //    email = "fdn_2004@ukr.net",
            //    password = "fhtcnjD_117"
            //};
            var loginData = new
            {
                email = "il@most-it.com.ua",
                password = "Azl&306qcB"
            };
            string jsonData = JsonConvert.SerializeObject(loginData);
            return new StringContent(jsonData, Encoding.UTF8, "application/json");
        }
        #endregion

        #region EXCEL
        private static void GlueXLSX()
        {
            using (var filePathFirst = new ExcelPackage(new FileInfo(_filePathFirst)))
            {
                var worksheet1 = filePathFirst.Workbook.Worksheets[0];
                int lastRow1 = worksheet1.Dimension.End.Row;

                // Загрузка данных из file2.xlsx
                using (var filePathSecond = new ExcelPackage(new FileInfo(_filePathSecond)))
                {
                    var worksheet2 = filePathSecond.Workbook.Worksheets[0];
                    int lastRow2 = worksheet2.Dimension.End.Row;

                    // Copy data from file2.xlsx to file1.xlsx
                    for (int row = 2; row <= lastRow2; row++)
                    {
                        for (int column = 1; column <= worksheet2.Dimension.End.Column; column++)
                        {
                            var sourceValue = worksheet2.Cells[row, column].Value;
                            worksheet1.Cells[lastRow1 + row, column].Value = sourceValue;
                        }
                    }
                    filePathFirst.SaveAs(new FileInfo(_filePathResult));
                }
            }
        }
        private static async Task<Stream> GetDataStream(string suffix)
        {
            var response = await client.GetAsync(DOMAIN_USPACY + suffix);
            return await response.Content.ReadAsStreamAsync();
        }
        private static IEnumerable<string> GetLines(string suffix)
        {
            using var _dataStream = GetDataStream(suffix).Result;
            using var _dataReader = new StreamReader(_dataStream);
            while (!_dataReader.EndOfStream)
            {
                var line = _dataReader.ReadLine();
                if (string.IsNullOrWhiteSpace(line)) continue;
                yield return line;
            }
        }
        #endregion

        #endregion
    }
}