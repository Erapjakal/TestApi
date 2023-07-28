using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json.Serialization;
using System.Xml;
using System.Xml.Serialization;

namespace UspacyToPerfectum
{
    public class Program
    {
        #region private properties
        private static List<Funnel> uspacyFunnel = new List<Funnel>();
        private static Kanban uspacyKanban = new Kanban();
        #endregion

        #region readonlyes
        private static readonly string PERFECTUMAPIKEY = "82c6d13ac58036e4db231650e8f6bea5";
        private static readonly string DOMAIN_PERFECTUM = "https://mostit.perfectum.cloud/";
        private static readonly string DOMAIN_USPACY = "https://api.most-it.uspacy.ua";
        #endregion

        #region Адреса пароли явки
        public static string ApiSuffix { get; set; } = "";
        public static string PerfectumApiSuffix { get; set; } = "";
        #endregion

        #region Random email
        private static Random random = new Random();
        private static HashSet<int> generatedNumbers = new HashSet<int>();
        #endregion

        static async Task Main(string[] args)
        {
            #region tests perfect
            #region perfect client            
            /*var clientP = new HttpClient();
            var requestP = new HttpRequestMessage(HttpMethod.Get, "https://mostit.perfectum.cloud//api/clients/227");
            requestP.Headers.Add("APIKEY", PERFECTUMAPIKEY);
            var responseP = await clientP.SendAsync(requestP);
            responseP.EnsureSuccessStatusCode();
            var test = await responseP.Content.ReadAsStringAsync();*/
            #endregion
            #region perfect lead  
            //await GetLeadsAsync();
            //await AddLeadByClientId();
            /*var clientL = new HttpClient();
            var requestL = new HttpRequestMessage(HttpMethod.Get, "https://mostit.perfectum.cloud/api/leads");
            requestL.Headers.Add("APIKEY", PERFECTUMAPIKEY);
            var responseL = await clientL.SendAsync(requestL);
            responseL.EnsureSuccessStatusCode();
            var test = await responseL.Content.ReadAsStringAsync();
            Console.WriteLine("test lead downloaded");*/
            #endregion
            #endregion

            #region test uspecy
            /*XmlSerializer serializerR = new XmlSerializer(typeof(Deal));
            Deal deal;
            using (FileStream fileStream = new FileStream("deals.xml", FileMode.Open))
            {
                deal = (Deal)serializerR.Deserialize(fileStream);
            }
            string? sourceFound = null;
            int dealsCount = 0, selectedCount = 0;
            foreach (var dealData in deal?.Data)
            {
                dealsCount++;
                if (dealData.DealLabel != null)
                {
                    foreach (var source in dealData.DealLabel)
                    {
                        if (source.Selected)
                        {
                            sourceFound = source.Value;
                            Console.WriteLine($"Значение поля 'Value' в найденном объекте 'Source': {sourceFound}");
                            selectedCount++;
                        }
                    }
                }
            }
            Console.WriteLine($"dealsCount : {dealsCount}   selectedCount : {selectedCount}");*/
            #endregion

            #region http client
            HttpClientHandler handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = IgnoreCertificateValidation;
            var client = new HttpClient(handler);
            ApiSuffix = "https://most-it.uspacy.ua/auth/v1/auth/sign_in/";
            var httpResponse = await client.PostAsync(ApiSuffix, LoginCred());
            var responseStr = httpResponse.Content.ReadAsStringAsync().Result;
            var token = JsonConvert.DeserializeObject<TokenResponse>(responseStr);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token?.Jwt);
            #endregion

            #region uspacy export
            #region Funnel
            //https://{domain}.uspacy.ua/crm/v1/entities/{entity}/funnel
            ApiSuffix = "/crm/v1/entities/deals/funnel";
            foreach (var data_line in GetLines(ApiSuffix, client))
            {
#pragma warning disable CS8601 // Possible null reference assignment.
                uspacyFunnel = JsonConvert.DeserializeObject<List<Funnel>>(data_line);
#pragma warning restore CS8601 // Possible null reference assignment.
                Console.WriteLine("Загрузка Funnel завершена успешно");
            }
            #endregion
            #region Kanban
            //https://{domain}.uspacy.ua/crm/v1/entities/{entity}/kanban/stage
            ApiSuffix = "/crm/v1/entities/deals/kanban/stage";
            foreach (var data_line in GetLines(ApiSuffix, client))
            {
#pragma warning disable CS8601 // Possible null reference assignment.
                uspacyKanban = JsonConvert.DeserializeObject<Kanban>(data_line);
#pragma warning restore CS8601 // Possible null reference assignment.
                Console.WriteLine("Загрузка Kanban завершена успешно");
            }
            #endregion
            #region Staff
            //https://{domain}.uspacy.ua/company/v1/users/
            ApiSuffix = "/company/v1/users/";
            Stuff uspacyStuff = new();
            foreach (var data_line in GetLines(ApiSuffix, client))
            {
                uspacyStuff = JsonConvert.DeserializeObject<Stuff>(data_line);
                Console.WriteLine("Загрузка Stuff завершена успешно");
            }
            #endregion
            #region Company
            /*#region выгрузка всех компаний и запись в XML файл
            #region list of companies
            var companies = new List<Company>();
            for (int page = 1; page <= 16; page++)
            {
                int listPerPage = 500;
                ApiSuffix = $"/crm/v1/entities/companies/?page={page}&list={listPerPage}";
                Company uspacyCompanyItem = new();
                foreach (var data_line in GetLines(ApiSuffix, client))
                {
                    uspacyCompanyItem = JsonConvert.DeserializeObject<Company>(data_line);
                    Console.WriteLine($"Загрузка Company из страницы {page} завершена успешно");
                }
                companies.Add(uspacyCompanyItem);
            }
            #endregion
            #region create file.xml
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.OmitXmlDeclaration = true;
            settings.NamespaceHandling = NamespaceHandling.OmitDuplicates;
            XmlSerializer serializer = new XmlSerializer(typeof(CompanyData));
            using (FileStream fileStream = new FileStream("file.xml", FileMode.Create))
            {
                using (XmlWriter xmlWriter = XmlWriter.Create(fileStream, settings))
                {
                    xmlWriter.WriteStartElement("Companies");
                    foreach (var comp in companies)
                    {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                        foreach (var data in comp.Data)
                        {
                            serializer.Serialize(xmlWriter, data);
                        }
#pragma warning restore CS8602 // Dereference of a possibly null reference.
                    }
                    xmlWriter.WriteEndElement();
                }
            }
            #endregion
            #region clearing namespaces
            string xmlFilePath = "file.xml";
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlFilePath);
#pragma warning disable CS8604 // Possible null reference argument.
            RemoveXmlnsAttributes(xmlDoc.DocumentElement);
#pragma warning restore CS8604 // Possible null reference argument.
            xmlDoc.Save(xmlFilePath);
            Console.WriteLine("Атрибуты xmlns:xsi и xmlns:xsd успешно удалены из всех тегов в XML-файле.");
            #endregion
            #region reading from file
            XmlSerializer serializerR = new XmlSerializer(typeof(Company));
            Company company;
            using (FileStream fileStream = new FileStream("file.xml", FileMode.Open))
            {
                company = (Company)serializerR.Deserialize(fileStream);
            }
            #endregion
            #endregion*/
            ApiSuffix = "/crm/v1/entities/companies/?page=669&list=1";
            //ApiSuffix = "/crm/v1/entities/companies/3312";
            Company uspacyCompany = new();
            foreach (var data_line in GetLines(ApiSuffix, client))
            {
                //var companyById = JsonConvert.DeserializeObject<CompanyData>(data_line);
                //uspacyCompany.Data = new List<CompanyData>();
                //uspacyCompany.Data.Add(companyById);
                uspacyCompany = JsonConvert.DeserializeObject<Company>(data_line);
                Console.WriteLine("Загрузка Company завершена успешно");
            }
            #endregion
            #region Contacts
            #region выгрузка всех контактов и запись в XML файл
            /*#region list of contacts
            List<Contact>? contacts = new List<Contact>();
            for (int page = 1; page <= 18; page++)
            {
                int listPerPage = 500;
                ApiSuffix = $"/crm/v1/entities/contacts/?page={page}&list={listPerPage}";
                Contact uspacyContactItem = new();
                foreach (var data_line in GetLines(ApiSuffix, client))
                {
                    uspacyContactItem = JsonConvert.DeserializeObject<Contact>(data_line);
                    Console.WriteLine($"Загрузка Contact из страницы {page} завершена успешно");
                }
                contacts.Add(uspacyContactItem);
            }
            #endregion
            #region create file.xml
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.OmitXmlDeclaration = true;
            settings.NamespaceHandling = NamespaceHandling.OmitDuplicates;
            XmlSerializer serializer = new XmlSerializer(typeof(ContactData));
            using (FileStream fileStream = new FileStream("contacts.xml", FileMode.Create))
            {
                using (XmlWriter xmlWriter = XmlWriter.Create(fileStream, settings))
                {
                    xmlWriter.WriteStartElement("Contacts");
                    foreach (var cont in contacts)
                    {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                        foreach (var data in cont.Data)
                        {
                            serializer.Serialize(xmlWriter, data);
                        }
#pragma warning restore CS8602 // Dereference of a possibly null reference.
                    }
                    xmlWriter.WriteEndElement();
                }
            }
            #endregion
            #region clearing namespaces
            string xmlFilePath = "contacts.xml";
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlFilePath);
#pragma warning disable CS8604 // Possible null reference argument.
            RemoveXmlnsAttributes(xmlDoc.DocumentElement);
#pragma warning restore CS8604 // Possible null reference argument.
            xmlDoc.Save(xmlFilePath);
            Console.WriteLine("Атрибуты xmlns:xsi и xmlns:xsd успешно удалены из всех тегов в XML-файле.");
            #endregion
            #region reading from file
            XmlSerializer serializerR = new XmlSerializer(typeof(Contact));
            Contact contact;
            using (FileStream fileStream = new FileStream("contacts.xml", FileMode.Open))
            {
                contact = (Contact)serializerR.Deserialize(fileStream);
            }
            #endregion*/
            #endregion
            //https://{domain}.uspacy.ua/crm/v1/entities/contacts/
            ApiSuffix = "/crm/v1/entities/contacts/?page=1&list=1";
            Contact uspacyContact = new Contact();
            foreach (var data_line in GetLines(ApiSuffix, client))
            {
                uspacyContact = JsonConvert.DeserializeObject<Contact>(data_line);
                Console.WriteLine("Загрузка Contacts завершена успешно");
            }
            #endregion
            #region Deals
            #region выгрузка всех дел и запись в XML файл
            /*#region list of deals
            List<Deal>? deals = new List<Deal>();
            for (int page = 1; page <= 46; page++)
            {
                int listPerPage = 100;
                ApiSuffix = $"/crm/v1/entities/deals/?page={page}&list={listPerPage}";
                Deal uspacyDealItem = new();
                foreach (var data_line in GetLines(ApiSuffix, client))
                {
                    uspacyDealItem = JsonConvert.DeserializeObject<Deal>(data_line);
                    Console.WriteLine($"Загрузка Deal из страницы {page} завершена успешно");
                }
                deals.Add(uspacyDealItem);
            }
            #endregion
            #region create file.xml
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.OmitXmlDeclaration = true;
            settings.NamespaceHandling = NamespaceHandling.OmitDuplicates;
            XmlSerializer serializer = new XmlSerializer(typeof(DealData));
            using (FileStream fileStream = new FileStream("deals.xml", FileMode.Create))
            {
                using (XmlWriter xmlWriter = XmlWriter.Create(fileStream, settings))
                {
                    xmlWriter.WriteStartElement("Deals");
                    foreach (var dl in deals)
                    {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                        foreach (var data in dl.Data)
                        {
                            serializer.Serialize(xmlWriter, data);
                        }
#pragma warning restore CS8602 // Dereference of a possibly null reference.
                    }
                    xmlWriter.WriteEndElement();
                }
            }
            #endregion
            #region clearing namespaces
            string xmlFilePath = "deals.xml";
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlFilePath);
#pragma warning disable CS8604 // Possible null reference argument.
            RemoveXmlnsAttributes(xmlDoc.DocumentElement);
#pragma warning restore CS8604 // Possible null reference argument.
            xmlDoc.Save(xmlFilePath);
            Console.WriteLine("Атрибуты xmlns:xsi и xmlns:xsd успешно удалены из всех тегов в XML-файле.");
            #endregion
            #region reading from file
            XmlSerializer serializerR = new XmlSerializer(typeof(Deal));
            Deal deal;
            using (FileStream fileStream = new FileStream("deals.xml", FileMode.Open))
            {
                deal = (Deal)serializerR.Deserialize(fileStream);
            }
            #endregion*/
            #endregion
            //https://{domain}.uspacy.ua/crm/v1/entities/deals/
            ApiSuffix = "/crm/v1/entities/deals/?page=1&list=1";
            Deal uspacyDeal = new Deal();
            foreach (var data_line in GetLines(ApiSuffix, client))
            {
                uspacyDeal = JsonConvert.DeserializeObject<Deal>(data_line);
                Console.WriteLine("Загрузка Deal завершена успешно");
            }
            #endregion
            #region Leads
            #region выгрузка всех лидов и запись в XML файл
            /*#region list of deals
            List<Lead>? leads = new List<Lead>();
            for (int page = 1; page <= 56; page++)
            {
                int listPerPage = 100;
                ApiSuffix = $"/crm/v1/entities/leads/?page={page}&list={listPerPage}";
                Lead uspacyLeadItem = new();
                foreach (var data_line in GetLines(ApiSuffix, client))
                {
                    uspacyLeadItem = JsonConvert.DeserializeObject<Lead>(data_line);
                    Console.WriteLine($"Загрузка Lead из страницы {page} завершена успешно");
                }
                leads.Add(uspacyLeadItem);
            }
            #endregion
            #region create file.xml
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.OmitXmlDeclaration = true;
            settings.NamespaceHandling = NamespaceHandling.OmitDuplicates;
            XmlSerializer serializer = new XmlSerializer(typeof(LeadData));
            using (FileStream fileStream = new FileStream("leads.xml", FileMode.Create))
            {
                using (XmlWriter xmlWriter = XmlWriter.Create(fileStream, settings))
                {
                    xmlWriter.WriteStartElement("Leads");
                    foreach (var dl in leads)
                    {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                        foreach (var data in dl.Data)
                        {
                            serializer.Serialize(xmlWriter, data);
                        }
#pragma warning restore CS8602 // Dereference of a possibly null reference.
                    }
                    xmlWriter.WriteEndElement();
                }
            }
            #endregion
            #region clearing namespaces
            string xmlFilePath = "leads.xml";
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlFilePath);
#pragma warning disable CS8604 // Possible null reference argument.
            RemoveXmlnsAttributes(xmlDoc.DocumentElement);
#pragma warning restore CS8604 // Possible null reference argument.
            xmlDoc.Save(xmlFilePath);
            Console.WriteLine("Атрибуты xmlns:xsi и xmlns:xsd успешно удалены из всех тегов в XML-файле.");
            #endregion
            #region reading from file
            XmlSerializer serializerR = new XmlSerializer(typeof(Lead));
            Lead lead;
            using (FileStream fileStream = new FileStream("leads.xml", FileMode.Open))
            {
                lead = (Lead)serializerR.Deserialize(fileStream);
            }
            #endregion*/
            #endregion
            //https://{domain}.uspacy.ua/crm/v1/entities/leads/
            ApiSuffix = "/crm/v1/entities/leads/?page=1&list=1";
            Lead uspacyLead = new Lead();
            foreach (var data_line in GetLines(ApiSuffix, client))
            {
                uspacyLead = JsonConvert.DeserializeObject<Lead>(data_line);
                Console.WriteLine("Загрузка Lead завершена успешно");
            }
            #endregion
            #region task
            #region выгрузка всех лидов и запись в XML файл
            /*#region list of taks
            List<TaskUspacy>? tasks = new List<TaskUspacy>();
            for (int page = 1; page <= 174; page++)
            {
                int listPerPage = 500;
                ApiSuffix = $"/crm/v1/static/tasks/?page={page}&list={listPerPage}";
                TaskUspacy uspacyTaskUspacyItem = new();
                foreach (var data_line in GetLines(ApiSuffix, client))
                {
                    uspacyTaskUspacyItem = JsonConvert.DeserializeObject<TaskUspacy>(data_line);
                    Console.WriteLine($"Загрузка TaskUspacy из страницы {page} завершена успешно");
                }
                tasks.Add(uspacyTaskUspacyItem);
            }
            #endregion
            #region create file.xml
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.OmitXmlDeclaration = true;
            settings.NamespaceHandling = NamespaceHandling.OmitDuplicates;
            XmlSerializer serializer = new XmlSerializer(typeof(TaskData));
            using (FileStream fileStream = new FileStream("tasks.xml", FileMode.Create))
            {
                using (XmlWriter xmlWriter = XmlWriter.Create(fileStream, settings))
                {
                    xmlWriter.WriteStartElement("TaskUspacys");
                    foreach (var dl in tasks)
                    {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                        foreach (var data in dl.Data)
                        {
                            serializer.Serialize(xmlWriter, data);
                        }
#pragma warning restore CS8602 // Dereference of a possibly null reference.
                    }
                    xmlWriter.WriteEndElement();
                }
            }
            #endregion
            #region clearing namespaces
            string xmlFilePath = "tasks.xml";
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlFilePath);
#pragma warning disable CS8604 // Possible null reference argument.
            RemoveXmlnsAttributes(xmlDoc.DocumentElement);
#pragma warning restore CS8604 // Possible null reference argument.
            xmlDoc.Save(xmlFilePath);
            Console.WriteLine("Атрибуты xmlns:xsi и xmlns:xsd успешно удалены из всех тегов в XML-файле.");
            #endregion
            #region reading from file
            XmlSerializer serializerR = new XmlSerializer(typeof(TaskUspacy));
            TaskUspacy task;
            using (FileStream fileStream = new FileStream("tasks.xml", FileMode.Open))
            {
                task = (TaskUspacy)serializerR.Deserialize(fileStream);
            }
            #endregion*/
            #endregion
            //https://{domain}.uspacy.ua/crm/v1/static/tasks/
            ApiSuffix = "/crm/v1/static/tasks/?page=1&list=1";
            TaskUspacy uspacyTask = new TaskUspacy();
            foreach (var data_line in GetLines(ApiSuffix, client))
            {
                uspacyTask = JsonConvert.DeserializeObject<TaskUspacy>(data_line);
                Console.WriteLine("Загрузка TaskUspacy завершена успешно");
            }
            #endregion
            #region calls
            #region выгрузка всех звонков и запись в XML файл
            /*#region list of calls
            List<Calls>? calls = new List<Calls>();
            for (int page = 1; page <= 2; page++)
            {
                int listPerPage = 100;
                ApiSuffix = $"/crm/v1/events/call/?page={page}&list={listPerPage}";
                Calls uspacyCallsItem = new();
                foreach (var data_line in GetLines(ApiSuffix, client))
                {
                    uspacyCallsItem = JsonConvert.DeserializeObject<Calls>(data_line);
                    Console.WriteLine($"Загрузка Calls из страницы {page} завершена успешно");
                }
                calls.Add(uspacyCallsItem);
            }
            #endregion
            #region create file.xml
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.OmitXmlDeclaration = true;
            settings.NamespaceHandling = NamespaceHandling.OmitDuplicates;
            XmlSerializer serializer = new XmlSerializer(typeof(CallData));
            using (FileStream fileStream = new FileStream("calls.xml", FileMode.Create))
            {
                using (XmlWriter xmlWriter = XmlWriter.Create(fileStream, settings))
                {
                    xmlWriter.WriteStartElement("Calls");
                    foreach (var dl in calls)
                    {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                        foreach (var data in dl.Data)
                        {
                            serializer.Serialize(xmlWriter, data);
                        }
#pragma warning restore CS8602 // Dereference of a possibly null reference.
                    }
                    xmlWriter.WriteEndElement();
                }
            }
            #endregion
            #region clearing namespaces
            string xmlFilePath = "calls.xml";
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlFilePath);
#pragma warning disable CS8604 // Possible null reference argument.
            RemoveXmlnsAttributes(xmlDoc.DocumentElement);
#pragma warning restore CS8604 // Possible null reference argument.
            xmlDoc.Save(xmlFilePath);
            Console.WriteLine("Атрибуты xmlns:xsi и xmlns:xsd успешно удалены из всех тегов в XML-файле.");
            #endregion
            #region reading from file
            XmlSerializer serializerR = new XmlSerializer(typeof(Calls));
            Calls call;
            using (FileStream fileStream = new FileStream("calls.xml", FileMode.Open))
            {
                call = (Calls)serializerR.Deserialize(fileStream);
            }
            #endregion*/
            #endregion
            //https://{domain}.uspacy.ua/crm/v1/events/call
            ApiSuffix = "/crm/v1/events/call/?page=1&list=1";
            var uspacyCalls = new Calls();
            foreach (var data_line in GetLines(ApiSuffix, client))
            {
                uspacyCalls = JsonConvert.DeserializeObject<Calls>(data_line);
                Console.WriteLine("Загрузка Calls завершена успешно");
            }
            #endregion
            #endregion

            #region perfectum import
            var perfectStaffs = PerfectumGetStaff();
            var pManagers = JsonConvert.DeserializeObject<PerfectumStuff>(perfectStaffs);
#pragma warning disable CS8604 // Possible null reference argument.
            await PerfectumAddClient(uspacyCompany, uspacyStuff, pManagers);
#pragma warning restore CS8604 // Possible null reference argument.
            #endregion
            await Console.Out.WriteLineAsync("import complete");
            Console.ReadLine();
        }
        #region helpers
        private static bool IgnoreCertificateValidation(HttpRequestMessage? request, X509Certificate2? certificate, X509Chain? chain, SslPolicyErrors sslPolicyErrors)
        {
            // Возвращаем true, чтобы принять любой сертификат без проверки
            return true;
        }
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
        private static async Task<Stream> GetDataStream(string suffix, HttpClient httpClient)
        {
            var response = await httpClient.GetAsync(DOMAIN_USPACY + suffix);
            return await response.Content.ReadAsStreamAsync();
        }
        private static IEnumerable<string> GetLines(string suffix, HttpClient httpClient)
        {
            using var _dataStream = GetDataStream(suffix, httpClient).Result;
            using var _dataReader = new StreamReader(_dataStream);
            while (!_dataReader.EndOfStream)
            {
                var line = _dataReader.ReadLine();
                if (string.IsNullOrWhiteSpace(line)) continue;
                yield return line;
            }
        }
        private static string GetEmail(CompanyData uC, Contacts contact)
        {
            string email = contact?.Email?.FirstOrDefault()?.Value ?? uC?.Email?.FirstOrDefault()?.Value;

            if (string.IsNullOrEmpty(email))
            {
                email = GenerateUniqueEmail();
            }

            return email;
        }
        private static string GenerateUniqueEmail()
        {
            int generatedNumber;
            string email;

            do
            {
                generatedNumber = random.Next(1000000);
            }
            while (!IsUniqueNumber(generatedNumber));

            email = $"noemail{generatedNumber}@net.ua";
            return email;
        }
        private static bool IsUniqueNumber(int number)
        {
            if (generatedNumbers.Contains(number))
            {
                return false;
            }

            generatedNumbers.Add(number);
            return true;
        }
        private static void RemoveXmlnsAttributes(XmlElement element)
        {
            // Удаление атрибутов xmlns:xsi и xmlns:xsd у текущего элемента
            element.RemoveAttribute("xmlns:xsi");
            element.RemoveAttribute("xmlns:xsd");

            // Рекурсивный вызов для всех дочерних элементов
            foreach (XmlNode childNode in element.ChildNodes)
            {
                if (childNode is XmlElement childElement)
                {
                    RemoveXmlnsAttributes(childElement);
                }
            }
        }
        #endregion
        #region perfectum cervices
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
        private static async Task PerfectumAddClient(Company uCompany, Stuff uStuff, PerfectumStuff perfectStaffs)
        {

#pragma warning disable CS8602 // Dereference of a possibly null reference.
            foreach (var uC in uCompany.Data)
            {
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
                string[] addressParts = uC?.Address?.Split(",");
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
                    Console.WriteLine("No adress in " + uC?.CompanyName);
                }
                #endregion
                #region Stuff
                var manager = new List<string>();
                manager = GetStuffId(uC, uStuff, perfectStaffs);
                #endregion
                #region Contacts
                var firstName = "";
                var lastName = "";
                var patronymic = "";
                if (uC?.Contacts != null && uC.Contacts.Count > 0)
                {
                    var contact = uC.Contacts.FirstOrDefault();

                    if (contact != null)
                    {
                        var FIO = contact?.Title?.Split(" ");

                        firstName = FIO?.ElementAtOrDefault(0)?.Trim();
                        lastName = FIO?.ElementAtOrDefault(1)?.Trim();
                        patronymic = FIO?.ElementAtOrDefault(2)?.Trim();
                    }
                }
                else
                {
                    Console.WriteLine("no contact " + uC?.CompanyName);
                }
                #endregion
                #endregion
                #region Initialize Client
#pragma warning disable CS8604 // Possible null reference argument.
                var customField = new ClientCustomFields()
                {
                    Customers = new ClientCustomers()
                    {
                        Comment = uC?.Comments ?? "no comments",
                        ShareLink = $"<a href={uC.SharePoint}>" + "linkToSharePoint" + "</a>" ?? ""
                    }
                };
#pragma warning restore CS8604 // Possible null reference argument.
                var pClient = new Client()
                {
                    Company = (uC?.CompanyName) ?? " ",
                    Phonenumber = (uC?.Phone?.FirstOrDefault()?.Value) ?? uC?.Contacts?.FirstOrDefault()?.Phone?.FirstOrDefault()?.Value,
                    EmailCompany = (uC?.Email?.FirstOrDefault()?.Value) ?? uC?.Contacts?.FirstOrDefault()?.Email?.FirstOrDefault()?.Value,
                    Website = (uC?.Site) ?? "cauta.net",
                    City = (PhysicalAddressCity) ?? "City",
                    Country = (PhysicalAddressCountry) ?? "Country",
                    Zip = (PhysicalAddressPostalCode) ?? "61000",
                    Address = (PhysicalAddressStreet) ?? "adress",
                    State = (PhysicalAdressRegion) ?? "oblast",
                    CustomerAdmins = manager,
                    CustomFields = customField
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
                var perfectClientID = JsonConvert.DeserializeObject<ResponseWhenClientWasAdded>(responseImport.Content.ReadAsStringAsync().Result);
                Thread.Sleep(TimeSpan.FromSeconds(2));
#pragma warning disable CS8604 // Possible null reference argument.
                await AddContactByClientId(perfectClientID.Id, uC);
#pragma warning restore CS8604 // Possible null reference argument.
                /*Console.WriteLine("добавляю реквезит - " + pClient.Company);
                await AddRekvezitByClientId(perfectClientID.Id);
                Thread.Sleep(TimeSpan.FromSeconds(2));*/
                Console.WriteLine("добавляю лид - " + pClient.Company);
                await AddDealByClientId(perfectClientID.Id, manager);
                #endregion
            }
#pragma warning restore CS8602 // Dereference of a possibly null reference.
        }
        private static List<string> GetStuffId(CompanyData? uC, Stuff uStuff, PerfectumStuff perfectStaffs)
        {
            var managerId = new List<string>();
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            foreach (var item in uStuff.Data)
            {
                if (item.Id == uC?.Owner)
                {
#pragma warning disable CS8604 // Possible null reference argument.
                    managerId.Add(perfectStaffs.Data
                        .FirstOrDefault(pm =>
                        item.FirstName == pm.Firstname
                        &&
                        item.LastName.Replace(" new", "")
                        ==
                        pm.Lastname)?
                        .Staffid);
#pragma warning restore CS8604 // Possible null reference argument.
                }
            }
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            return managerId;
        }
        private static async Task AddContactByClientId(int id, CompanyData uC)
        {
            if (uC.Contacts != null)
            {
                if (uC.Contacts.Count > 0)
                {
                    foreach (var contact in uC.Contacts)
                    {
                        #region Name cheking
                        var FIO = contact?.Title?.Split(" ");
                        string? firstName = FIO?.ElementAtOrDefault(0)?.Trim();
                        string? lastName = FIO?.ElementAtOrDefault(1)?.Trim();
                        string? patronymic = FIO?.ElementAtOrDefault(2)?.Trim();
                        #endregion
                        #region Phone cheking
                        var phoneNumbers = uC?.Phone?.Select(phone => phone.Value);
                        var combinedPhoneNumbers = phoneNumbers != null ? string.Join(",", phoneNumbers) : " ";
                        #endregion
                        var emails = uC?.Email?.Select(mail => mail.Value);
                        var combinedEmails = emails != null ? string.Join(";", emails) : " ";
#pragma warning disable CS8604 // Possible null reference argument.
                        var email = GetEmail(uC, contact);
#pragma warning restore CS8604 // Possible null reference argument.
                        #region Init Contact 
                        var contactToAdd = new ClientContactToConvert()
                        {
                            Userid = id.ToString(),
                            IsPrimary = "1",
                            Donotsendwelcomeemail = "1",
                            Firstname = (firstName) ?? "name",
                            Lastname = (lastName) ?? "lastName",
                            Patronymic = (patronymic) ?? "",
                            Phonenumber = (contact?.Phone?.FirstOrDefault()?.Value) ?? uC?.Phone?.FirstOrDefault()?.Value,
                            PhonenumberAdditional = combinedPhoneNumbers,
                            Email = email,
                            EmailAdditional = combinedEmails
                        };
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
        private static async Task AddRekvezitByClientId(int id)
        {
            var rekCustomFields = new RekvezitCustomFields()
            {
                Entities = new RekvezitEntities()
                {
                    _2 = "+380933897546",
                    _3 = "40312010133450221938",
                    _4 = "Рекламный агент",
                    _5 = "Мирон Горенченко",
                    _6 = "300335",
                    _7 = "14305909",
                    _8 = "554948126757"
                }
            };
            var rekvezitToAdd = new RekvezitToClientById()
            {
                ClientId = id.ToString(),
                Name = "Name of person",
                IsDefault = "0",
                Info = "info@client.ru",
                BillingCountry = "233",
                BillingState = "oblast",
                BillingZip = "61000",
                BillingCity = "City",
                BillingStreet = "AdressFrom",
                ShippingCountry = "233",
                ShippingState = "oblast",
                ShippingZip = "61000",
                ShippingCity = "City",
                ShippingStreet = "AdressTo",
                CustomFields = rekCustomFields
            };
            #region Import rekvezit            
            PerfectumApiSuffix = "/api/entities";
            var clientRekvezit = new HttpClient();
            var requestRekvezit = new HttpRequestMessage(HttpMethod.Post, DOMAIN_PERFECTUM + PerfectumApiSuffix);
            requestRekvezit.Headers.Add("APIKEY", PERFECTUMAPIKEY);
            var content = new StringContent(JsonConvert.SerializeObject(rekvezitToAdd));
            requestRekvezit.Content = content;
            var responseRekvezit = await clientRekvezit.SendAsync(requestRekvezit);
            responseRekvezit.EnsureSuccessStatusCode();
            Console.WriteLine("реквезит" + rekvezitToAdd.Name + $"добавлен к клиенту {id}");
            #endregion
        }
        private static async Task AddDealByClientId(int id, List<string> manager)
        {
            #region getting client
            var json = await GetClientById(id);
            var client = JsonConvert.DeserializeObject<ClientFromPerfect>(json);
            #endregion
            #region reading from file
            XmlSerializer serializerR = new XmlSerializer(typeof(Deal));
            Deal deal;
            using (FileStream fileStream = new FileStream("deals.xml", FileMode.Open))
            {
                deal = (Deal)serializerR.Deserialize(fileStream);
            }
            #endregion
            #region finding matches
#pragma warning disable CS8604 // Possible null reference argument.
            var test = deal?.Data.FirstOrDefault(ld =>
            (ld.Companies != null &&
            ld.Companies.Any(company => company.Title == client?.Client?.Company)) ||
            (ld.Contacts != null &&
            ld.Contacts.Any(contact => contact.Title == client?.Client?.Company)));
#pragma warning restore CS8604 // Possible null reference argument.
            if (test == null)
            {
                Console.WriteLine($"no deal here : {client?.Client?.Userid}");
                return;
            }
            #endregion
            #region deal init to import
            Dictionary<int, string> kanbanStatusMapping = new Dictionary<int, string>
            {
                { 16, "3" },
                { 17, "1" },
                { 18, "11" },
                { 19, "3" },
                { 20, "4" },
                { 21, "5" },
                { 22, "6" },
                { 23, "7" },
                { 24, "8" },
                { 25, "8" },
                { 26, "9" },
                { 1, "3" },
                { 2, "3" },
                { 3, "3" },
                { 4, "3" },
                { 5, "3" },
                { 6, "3" },
                { 7, "3" },
                { 8, "3" },
                { 9, "3" },
                { 10, "3" },
                { 11, "3" },
                { 12, "3" },
                { 13, "3" },
                { 14, "3" },
                { 15, "3" },
                { 27, "3" },
                { 28, "1" },
                { 29, "11" },
                { 30, "4" },
                { 31, "5" },
                { 32, "8" },
                { 33, "6" },
                { 34, "9" },
                { 35, "12" },
                { 36, "1" },
                { 37, "11" },
                { 38, "12" },
                { 39, "13" },
                { 40, "14" },
                { 41, "15" },
                { 42, "15" },
                { 43, "8" },
                { 44, "6" },
                { 45, "9" },
                { 46, "21" },
                { 47, "1" },
                { 48, "11" },
                { 49, "6" },
                { 50, "7" },
                { 51, "8" },
                { 52, "8" },
                { 53, "3" },
                { 54, "1" },
                { 55, "11" },
                { 56, "3" },
                { 57, "8" },
                { 58, "8" },
                { 59, "19" }
            };
            string? status = "";
            kanbanStatusMapping.TryGetValue(test.KanbanStageId, out status);
            var dealToImport = new LeadPerfectum()
            {
                Status = status,
                Name = client?.Client?.Company,
                Source = "2",
                Company = client?.Client?.Company ?? "CompanyName",
                Assigned = client?.Client?.CustomerAdmins?.FirstOrDefault(),
                ClientId = id.ToString()
            };
            #endregion
            #region import lead
            PerfectumApiSuffix = "api/leads";
            var clientLead = new HttpClient();
            var requestLead = new HttpRequestMessage(HttpMethod.Post, DOMAIN_PERFECTUM + PerfectumApiSuffix);
            requestLead.Headers.Add("APIKEY", PERFECTUMAPIKEY);
            var content = new StringContent(JsonConvert.SerializeObject(dealToImport));
            requestLead.Content = content;
            var responseLead = await clientLead.SendAsync(requestLead);
            Console.WriteLine(responseLead.Content.ReadAsStringAsync().Result);
            Thread.Sleep(TimeSpan.FromSeconds(2));
            var patchId = JsonConvert.DeserializeObject<ResponseLead>(responseLead.Content.ReadAsStringAsync().Result);
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            await PatchLead(patchId.Id, dealToImport, status);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            #endregion
        }
        private static async Task GetLeadsAsync()
        {

            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, "https://mostit.perfectum.cloud/api/leads/31");
            request.Headers.Add("APIKEY", PERFECTUMAPIKEY);
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var test = response.Content.ReadAsStringAsync().Result;
            Console.WriteLine(await response.Content.ReadAsStringAsync());

        }
        private static async Task<string> GetClientById(int id)
        {
            //https://{{domain}}/api/clients/{{client_id}}
            PerfectumApiSuffix = $"api/clients/{id}";
            var clientId = new HttpClient();
            var requestId = new HttpRequestMessage(HttpMethod.Get, DOMAIN_PERFECTUM + PerfectumApiSuffix);
            requestId.Headers.Add("APIKEY", PERFECTUMAPIKEY);
            var responseId = await clientId.SendAsync(requestId);
            responseId.EnsureSuccessStatusCode();
#pragma warning disable CS8603 // Possible null reference return.
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            return responseId.Content.ReadAsStringAsync().Result;
#pragma warning restore CS8602 // Dereference of a possibly null reference.
#pragma warning restore CS8603 // Possible null reference return.
        }
        private static async Task PatchLead(int id, LeadPerfectum dealToImport, string? status)
        {
            dealToImport.Status = status;
            #region import lead
            PerfectumApiSuffix = $"api/leads/{id}";
            var clientLead = new HttpClient();
            var requestLead = new HttpRequestMessage(HttpMethod.Patch, DOMAIN_PERFECTUM + PerfectumApiSuffix);
            requestLead.Headers.Add("APIKEY", PERFECTUMAPIKEY);
            var content = new StringContent(JsonConvert.SerializeObject(dealToImport));
            requestLead.Content = content;
            var responseLead = await clientLead.SendAsync(requestLead);
            Console.WriteLine(responseLead.Content.ReadAsStringAsync().Result);
            Thread.Sleep(TimeSpan.FromSeconds(2));
            #endregion
        }
        #endregion

        #region USPACY
        #region общие классы
        public class Reason
        {
            [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("id")]
            public int Id { get; set; }
            [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("title")]
            public string? Title { get; set; }
            [JsonProperty("sort", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("sort")]
            public int Sort { get; set; }
        }
        public class Link
        {
            [JsonProperty("url", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("url")]
            public string? Url { get; set; }
            [JsonProperty("label", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("label")]
            public string? Label { get; set; }
            [JsonProperty("active", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("active")]
            public bool Active { get; set; }
            [JsonProperty("first", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("first")]
            public string? First { get; set; }
            [JsonProperty("last", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("last")]
            public string? Last { get; set; }
            [JsonProperty("prev", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("prev")]
            public string? Prev { get; set; }
            [JsonProperty("next", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("next")]
            public string? Next { get; set; }
        }
        public class Meta
        {
            [JsonProperty("current_page", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("current_page")]
            public int CurrentPage { get; set; }
            [JsonProperty("from", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("from")]
            public int From { get; set; }
            [JsonProperty("last_page", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("last_page")]
            public int LastPage { get; set; }
            [JsonProperty("links", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("links")]
            public List<Link>? Links { get; set; }
            [JsonProperty("path", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("path")]
            public string? Path { get; set; }
            [JsonProperty("per_page", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("per_page")]
            public int PerPage { get; set; }
            [JsonProperty("to", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("to")]
            public int To { get; set; }
            [JsonProperty("total", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("total")]
            public int Total { get; set; }
        }
        public class Source
        {
            [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("title")]
            public string? Title { get; set; }

            [JsonProperty("value", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("value")]
            public string? Value { get; set; }

            [JsonProperty("color", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("color")]
            public string? Color { get; set; }

            [JsonProperty("sort", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("sort")]
            public int Sort { get; set; }

            [JsonProperty("selected", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("selected")]
            public bool Selected { get; set; }
        }
        public class Email
        {
            [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("id")]
            public string? Id { get; set; }
            [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("type")]
            public string? Type { get; set; }
            [JsonProperty("value", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("value")]
            public string? Value { get; set; }
            [JsonProperty("main", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("main")]
            public bool Main { get; set; }
        }
        public class Phone
        {
            [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("id")]
            public string? Id { get; set; }
            [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("type")]
            public string? Type { get; set; }
            [JsonProperty("value", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("value")]
            public string? Value { get; set; }
            [JsonProperty("main", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("main")]
            public bool Main { get; set; }
        }
        public class SocialMedia
        {
            [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("id")]
            public string? Id { get; set; }

            [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("name")]
            public string? Name { get; set; }

            [JsonProperty("link", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("link")]
            public string? Link { get; set; }

            [JsonProperty("sort", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("sort")]
            public string? Sort { get; set; }
        }
        public class Label
        {
            [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("title")]
            public string? Title { get; set; }

            [JsonProperty("value", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("value")]
            public string? Value { get; set; }

            [JsonProperty("color", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("color")]
            public string? Color { get; set; }

            [JsonProperty("sort", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("sort")]
            public int Sort { get; set; }

            [JsonProperty("selected", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("selected")]
            public bool Selected { get; set; }
        }
        public class Contacts
        {
            [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("id")]
            public int Id { get; set; }
            [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("title")]
            public string? Title { get; set; }
            [JsonProperty("phone", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("phone")]
            public List<Phone>? Phone { get; set; }
            [JsonProperty("email", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("email")]
            public List<Email>? Email { get; set; }
        }
        public class Companies
        {
            [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("id")]
            public int Id { get; set; }
            [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("title")]
            public string? Title { get; set; }
            [JsonProperty("phone", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("phone")]
            public List<Phone>? Phone { get; set; }
            [JsonProperty("email", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("email")]
            public List<Email>? Email { get; set; }
        }
        #endregion
        #region funnel 
        public class Funnel
        {
            [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("id")]
            public int Id { get; set; }
            [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("title")]
            public string? Title { get; set; }
            [JsonProperty("funnel_code", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("funnel_code")]
            public string? FunnelCode { get; set; }
            [JsonProperty("default", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("default")]
            public bool Default { get; set; }
            [JsonProperty("active", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("active")]
            public bool Active { get; set; }
            [JsonProperty("stages", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("stages")]
            public List<Stage>? Stages { get; set; }
        }
        public class Stage
        {
            [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("id")]
            public int Id { get; set; }
            [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("title")]
            public string? Title { get; set; }
            [JsonProperty("stage_code", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("stage_code")]
            public string? StageCode { get; set; }
            [JsonProperty("color", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("color")]
            public string? Color { get; set; }
            [JsonProperty("sort", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("sort")]
            public string? Sort { get; set; }
            [JsonProperty("system_stage", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("system_stage")]
            public bool SystemStage { get; set; }
            [JsonProperty("reasons", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("reasons")]
            public List<Reason>? Reasons { get; set; }
        }
        #endregion
        #region kanban
        public class KanbanData
        {
            [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("id")]
            public int Id { get; set; }
            [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("title")]
            public string? Title { get; set; }
            [JsonProperty("stage_code", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("stage_code")]
            public string? StageCode { get; set; }
            [JsonProperty("color", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("color")]
            public string? Color { get; set; }
            [JsonProperty("sort", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("sort")]
            public string? Sort { get; set; }
            [JsonProperty("system_stage", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("system_stage")]
            public bool SystemStage { get; set; }
            [JsonProperty("reasons", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("reasons")]
            public List<Reason>? Reasons { get; set; }
        }
        public class Kanban
        {
            [JsonProperty("data", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("data")]
            public List<KanbanData>? Data { get; set; }
        }
        #endregion
        #region Token
        public class TokenResponse
        {
            [JsonProperty("jwt", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("jwt")]
            public string? Jwt { get; set; }

            [JsonProperty("refreshToken", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("refreshToken")]
            public string? RefreshToken { get; set; }

            [JsonProperty("expireInSeconds", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("expireInSeconds")]
            public int ExpireInSeconds { get; set; }
        }
        #endregion
        #region Staff
        public class StuffData
        {
            [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("id")]
            public int Id { get; set; }
            [JsonProperty("patronymic", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("patronymic")]
            public string? Patronymic { get; set; }
            [JsonProperty("email", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("email")]
            public List<Email>? Email { get; set; }
            [JsonProperty("active", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("active")]
            public bool Active { get; set; }
            [JsonProperty("registered", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("registered")]
            public bool Registered { get; set; }
            [JsonProperty("position", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("position")]
            public string? Position { get; set; }
            [JsonProperty("birthday", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("birthday")]
            public int? Birthday { get; set; }
            [JsonProperty("specialization", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("specialization")]
            public string? Specialization { get; set; }
            [JsonProperty("country", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("country")]
            public string? Country { get; set; }
            [JsonProperty("city", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("city")]
            public string? City { get; set; }
            [JsonProperty("avatar", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("avatar")]
            public string? Avatar { get; set; }
            [JsonProperty("auth_user_id", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("auth_user_id")]
            public object? AuthUserId { get; set; }
            [JsonProperty("is_app_bot", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("is_app_bot")]
            public bool IsAppBot { get; set; }
            [JsonProperty("firstName", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("firstName")]
            public string? FirstName { get; set; }
            [JsonProperty("lastName", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("lastName")]
            public string? LastName { get; set; }
            [JsonProperty("aboutMyself", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("aboutMyself")]
            public string? AboutMyself { get; set; }
            [JsonProperty("showBirthYear", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("showBirthYear")]
            public bool ShowBirthYear { get; set; }
            [JsonProperty("phone", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("phone")]
            public List<Phone>? Phone { get; set; }
            [JsonProperty("departmentsIds", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("departmentsIds")]
            public List<string>? DepartmentsIds { get; set; }
            [JsonProperty("roles", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("roles")]
            public List<string>? Roles { get; set; }
            [JsonProperty("socialMedia", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("socialMedia")]
            public List<SocialMedia>? SocialMedia { get; set; }
        }
        public class Stuff
        {
            [JsonProperty("data", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("data")]
            public List<StuffData>? Data { get; set; }
            [JsonProperty("meta", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("meta")]
            public Meta? Meta { get; set; }
        }
        #endregion
        #region Company
        public class CompanyData
        {
            [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("id")]
            public int Id { get; set; }
            [JsonProperty("created_at", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("created_at")]
            public int CreatedAt { get; set; }
            [JsonProperty("updated_at", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("updated_at")]
            public int UpdatedAt { get; set; }
            [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("title")]
            public string? Title { get; set; }
            [JsonProperty("owner", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("owner")]
            public int Owner { get; set; }
            [JsonProperty("created_by", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("created_by")]
            public int CreatedBy { get; set; }
            [JsonProperty("changed_by", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("changed_by")]
            public int ChangedBy { get; set; }
            [JsonProperty("converted", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("converted")]
            public bool Converted { get; set; }
            [JsonProperty("company_name", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("company_name")]
            public string? CompanyName { get; set; }
            [JsonProperty("utm_source", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("utm_source")]
            public string? UtmSource { get; set; }
            [JsonProperty("utm_medium", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("utm_medium")]
            public string? UtmMedium { get; set; }
            [JsonProperty("utm_campaign", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("utm_campaign")]
            public string? UtmCampaign { get; set; }
            [JsonProperty("utm_content", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("utm_content")]
            public string? UtmContent { get; set; }
            [JsonProperty("utm_term", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("utm_term")]
            public string? UtmTerm { get; set; }
            [XmlElement("MessengerCompany")]
            [JsonProperty("messengers", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("messengers")]
            public List<SocialMedia>? Messengers { get; set; }
            [XmlElement("PhoneCompany")]
            [JsonProperty("phone", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("phone")]
            public List<Phone>? Phone { get; set; }
            [XmlElement("Emails")]
            [JsonProperty("email", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("email")]
            public List<Email>? Email { get; set; }
            [JsonProperty("comments", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("comments")]
            public string? Comments { get; set; }
            [XmlElement("Source")]
            [JsonProperty("source", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("source")]
            public List<Source>? Source { get; set; }
            [XmlElement("CompanyLabel")]
            [JsonProperty("company_label", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("company_label")]
            public List<Label>? CompanyLabel { get; set; }
            [JsonProperty("site", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("site")]
            public string? Site { get; set; }
            [JsonProperty("address", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("address")]
            public string? Address { get; set; }
            [XmlElement("CompanyContacts")]
            [JsonProperty("contacts", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("contacts")]
            public List<Contacts>? Contacts { get; set; }
            [XmlElement("IndustryLabelCompany")]
            [JsonProperty("industry_label", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("industry_label")]
            public List<Label>? IndustryLabel { get; set; }
            [XmlElement("EmployeesLabelCompany")]
            [JsonProperty("employees_label", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("employees_label")]
            public List<Label>? EmployeesLabel { get; set; }
            [JsonProperty("address_country", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("address_country")]
            public string? AddressCountry { get; set; }
            [JsonProperty("uf_crm_1633094809449", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("uf_crm_1633094809449")]
            public string? UfCrm1633094809449 { get; set; }
            [JsonProperty("uf_crm_64059cccb9a0d", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("uf_crm_64059cccb9a0d")]
            public string? UfCrm64059cccb9a0d { get; set; }
            [JsonProperty("uf_crm_1633095020302", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("uf_crm_1633095020302")]
            public string? UfCrm1633095020302 { get; set; }
            [JsonProperty("address_region", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("address_region")]
            public string? AddressRegion { get; set; }
            [JsonProperty("uf_crm_1633094830259", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("uf_crm_1633094830259")]
            public string? UfCrm1633094830259 { get; set; }
            [JsonProperty("address_city", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("address_city")]
            public string? AddressCity { get; set; }
            [JsonProperty("uf_crm_1632917200758", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("uf_crm_1632917200758")]
            public string? SharePoint { get; set; }
            [JsonProperty("address_2", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("address_2")]
            public string? Address2 { get; set; }
            [JsonProperty("uf_crm_1633094879095", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("uf_crm_1633094879095")]
            public string? UfCrm1633094879095 { get; set; }
            [JsonProperty("address_province", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("address_province")]
            public string? AddressProvince { get; set; }
            [JsonProperty("uf_crm_1633094857441", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("uf_crm_1633094857441")]
            public string? UfCrm1633094857441 { get; set; }
            [JsonProperty("uf_crm_1633094958676", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("uf_crm_1633094958676")]
            public string? UfCrm1633094958676 { get; set; }
            [JsonProperty("uf_crm_1633094913297", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("uf_crm_1633094913297")]
            public string? UfCrm1633094913297 { get; set; }
            [JsonProperty("address_postal_code", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("address_postal_code")]
            public string? AddressPostalCode { get; set; }
            [JsonProperty("uf_crm_1633094896324", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("uf_crm_1633094896324")]
            public string? UfCrm1633094896324 { get; set; }
            [JsonProperty("kanban_stage_id", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("kanban_stage_id")]
            public string? KanbanStageId { get; set; }
        }
        [XmlRoot("Companies")]
        public class Company
        {
            [XmlElement("CompanyData")]
            [JsonProperty("data", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("data")]
            public List<CompanyData>? Data { get; set; }

            [JsonProperty("links", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("links")]
            public Link? Links { get; set; }

            [JsonProperty("meta", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("meta")]
            public Meta? Meta { get; set; }
        }
        #endregion
        #region Contact        
        public class ContactData
        {
            [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("id")]
            public int Id { get; set; }
            [JsonProperty("created_at", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("created_at")]
            public int CreatedAt { get; set; }
            [JsonProperty("updated_at", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("updated_at")]
            public int UpdatedAt { get; set; }
            [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("title")]
            public string? Title { get; set; }
            [JsonProperty("owner", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("owner")]
            public int Owner { get; set; }
            [JsonProperty("created_by", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("created_by")]
            public int CreatedBy { get; set; }

            [JsonProperty("changed_by", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("changed_by")]
            public int ChangedBy { get; set; }
            [JsonProperty("converted", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("converted")]
            public bool Converted { get; set; }
            [JsonProperty("first_name", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("first_name")]
            public string? FirstName { get; set; }
            [JsonProperty("last_name", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("last_name")]
            public string? LastName { get; set; }
            [JsonProperty("patronymic", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("patronymic")]
            public string? Patronymic { get; set; }
            [JsonProperty("companies", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("companies")]
            public List<Companies>? Companies { get; set; }
            [JsonProperty("position", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("position")]
            public string? Position { get; set; }
            [JsonProperty("utm_source", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("utm_source")]
            public string? UtmSource { get; set; }
            [JsonProperty("utm_medium", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("utm_medium")]
            public string? UtmMedium { get; set; }
            [JsonProperty("utm_campaign", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("utm_campaign")]
            public string? UtmCampaign { get; set; }
            [JsonProperty("utm_content", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("utm_content")]
            public string? UtmContent { get; set; }
            [JsonProperty("utm_term", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("utm_term")]
            public string? UtmTerm { get; set; }
            [JsonProperty("messengers", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("messengers")]
            public string? Messengers { get; set; }
            [JsonProperty("phone", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("phone")]
            public List<Phone>? Phones { get; set; }
            [JsonProperty("email", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("email")]
            public List<Email>? Email { get; set; }
            [JsonProperty("comments", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("comments")]
            public string? Comments { get; set; }
            [JsonProperty("source", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("source")]
            public List<Source>? Source { get; set; }
            [JsonProperty("contact_label", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("contact_label")]
            public List<Label>? ContactLabel { get; set; }
            [JsonProperty("address_city", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("address_city")]
            public string? AddressCity { get; set; }
            [JsonProperty("address_2", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("address_2")]
            public string? Address2 { get; set; }
            [JsonProperty("uf_crm_1633092405601", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("uf_crm_1633092405601")]
            public string? UfCrm1633092405601 { get; set; }
            [JsonProperty("address_province", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("address_province")]
            public string? AddressProvince { get; set; }
            [JsonProperty("address", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("address")]
            public string? Address { get; set; }
            [JsonProperty("address_region", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("address_region")]
            public string? AddressRegion { get; set; }
            [JsonProperty("birthdate", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("birthdate")]
            public string? Birthdate { get; set; }
            [JsonProperty("post", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("post")]
            public string? Post { get; set; }
            [JsonProperty("address_country", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("address_country")]
            public string? AddressCountry { get; set; }
            [JsonProperty("address_loc_addr_id", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("address_loc_addr_id")]
            public string? AddressLocAddrId { get; set; }
            [JsonProperty("source_description", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("source_description")]
            public string? SourceDescription { get; set; }
            [JsonProperty("address_postal_code", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("address_postal_code")]
            public string? AddressPostalCode { get; set; }
            [JsonProperty("address_country_code", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("address_country_code")]
            public string? AddressCountryCode { get; set; }
            [JsonProperty("kanban_stage_id", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("kanban_stage_id")]
            public string? KanbanStageId { get; set; }
        }
        [XmlRoot("Contacts")]
        public class Contact
        {
            [XmlElement("ContactData")]
            [JsonProperty("data", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("data")]
            public List<ContactData>? Data { get; set; }
            [JsonProperty("links", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("links")]
            public Link? Links { get; set; }
            [JsonProperty("meta", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("meta")]
            public Meta? Meta { get; set; }
        }
        #endregion
        #region Task     
        public class TaskData
        {
            [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("id")]
            public int Id { get; set; }
            [JsonProperty("created_by", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("created_by")]
            public int CreatedBy { get; set; }
            [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("title")]
            public string? Title { get; set; }
            [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("type")]
            public string? Type { get; set; }
            [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("status")]
            public string? Status { get; set; }
            [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("description")]
            public string? Description { get; set; }
            [JsonProperty("start_time", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("start_time")]
            public int StartTime { get; set; }
            [JsonProperty("end_time", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("end_time")]
            public int EndTime { get; set; }
            [JsonProperty("responsible_id", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("responsible_id")]
            public int ResponsibleId { get; set; }
            [JsonProperty("company_id", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("company_id")]
            public int? CompanyId { get; set; }
            [JsonProperty("created_at", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("created_at")]
            public int CreatedAt { get; set; }
            [JsonProperty("updated_at", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("updated_at")]
            public int UpdatedAt { get; set; }
            [JsonProperty("company", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("company")]
            public CompanyData? Company { get; set; }
            [JsonProperty("contacts", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("contacts")]
            public List<ContactData>? Contacts { get; set; }
            [JsonProperty("deals", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("deals")]
            public List<DealData>? Deals { get; set; }
            [JsonProperty("leads", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("leads")]
            public List<LeadData>? Leads { get; set; }
        }
        [XmlRoot("TaskUspacys")]
        public class TaskUspacy
        {
            [XmlElement("TaskData")]
            [JsonProperty("data", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("data")]
            public List<TaskData>? Data { get; set; }
            [JsonProperty("links", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("links")]
            public Link? Links { get; set; }
            [JsonProperty("meta", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("meta")]
            public Meta? Meta { get; set; }
        }
        #endregion
        #region Deal
        public class AmountOfTheDeal
        {
            [JsonProperty("currency", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("currency")]
            public string? Currency { get; set; }
            [JsonProperty("value", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("value")]
            public string? Value { get; set; }
        }
        public class DealData
        {
            [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("id")]
            public int Id { get; set; }
            [JsonProperty("created_at", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("created_at")]
            public int CreatedAt { get; set; }
            [JsonProperty("updated_at", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("updated_at")]
            public int UpdatedAt { get; set; }
            [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("title")]
            public string? Title { get; set; }
            [JsonProperty("owner", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("owner")]
            public int Owner { get; set; }
            [JsonProperty("created_by", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("created_by")]
            public int CreatedBy { get; set; }
            [JsonProperty("changed_by", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("changed_by")]
            public int ChangedBy { get; set; }
            [JsonProperty("converted", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("converted")]
            public bool Converted { get; set; }
            [JsonProperty("amount_of_the_deal", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("amount_of_the_deal")]
            public AmountOfTheDeal? AmountOfTheDeal { get; set; }
            [JsonProperty("contacts", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("contacts")]
            public List<Contacts>? Contacts { get; set; }
            [JsonProperty("companies", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("companies")]
            public List<Companies>? Companies { get; set; }
            [JsonProperty("utm_source", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("utm_source")]
            public string? UtmSource { get; set; }
            [JsonProperty("utm_medium", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("utm_medium")]
            public string? UtmMedium { get; set; }
            [JsonProperty("utm_campaign", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("utm_campaign")]
            public string? UtmCampaign { get; set; }
            [JsonProperty("utm_content", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("utm_content")]
            public string? UtmContent { get; set; }
            [JsonProperty("utm_term", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("utm_term")]
            public string? UtmTerm { get; set; }
            [JsonProperty("comments", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("comments")]
            public string? Comments { get; set; }
            [JsonProperty("source", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("source")]
            public List<Source>? Source { get; set; }
            [JsonProperty("deal_label", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("deal_label")]
            public List<Label>? DealLabel { get; set; }
            [JsonProperty("kanban_status", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("kanban_status")]
            public string? KanbanStatus { get; set; }
            [JsonProperty("kanban_reason_id", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("kanban_reason_id")]
            public int KanbanReasonId { get; set; }
            [JsonProperty("uf_crm_1635844186", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("uf_crm_1635844186")]
            public string? UfCrm1635844186 { get; set; }
            [JsonProperty("uf_crm_1643976907290", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("uf_crm_1643976907290")]
            public List<Label>? UfCrm1643976907290 { get; set; }
            [JsonProperty("uf_crm_1633366687", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("uf_crm_1633366687")]
            public string? UfCrm1633366687 { get; set; }
            [JsonProperty("uf_crm_1633430326", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("uf_crm_1633430326")]
            public string? UfCrm1633430326 { get; set; }
            [JsonProperty("uf_crm_1635613706", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("uf_crm_1635613706")]
            public bool UfCrm1635613706 { get; set; }
            [JsonProperty("probability", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("probability")]
            public string? Probability { get; set; }
            [JsonProperty("uf_crm_1633366883", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("uf_crm_1633366883")]
            public string? UfCrm1633366883 { get; set; }
            [JsonProperty("uf_crm_1682054017546", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("uf_crm_1682054017546")]
            public string? UfCrm1682054017546 { get; set; }
            [JsonProperty("uf_crm_1633429677", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("uf_crm_1633429677")]
            public string? UfCrm1633429677 { get; set; }
            [JsonProperty("additional_info", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("additional_info")]
            public string? AdditionalInfo { get; set; }
            [JsonProperty("uf_crm_1633367478", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("uf_crm_1633367478")]
            public string? UfCrm1633367478 { get; set; }
            [JsonProperty("uf_crm_1633366948", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("uf_crm_1633366948")]
            public string? UfCrm1633366948 { get; set; }
            [JsonProperty("uf_crm_1633635449", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("uf_crm_1633635449")]
            public string? UfCrm1633635449 { get; set; }
            [JsonProperty("uf_crm_1638006384173", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("uf_crm_1638006384173")]
            public string? UfCrm1638006384173 { get; set; }
            [JsonProperty("uf_crm_1633366773", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("uf_crm_1633366773")]
            public string? UfCrm1633366773 { get; set; }
            [JsonProperty("uf_crm_1633367088", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("uf_crm_1633367088")]
            public string? UfCrm1633367088 { get; set; }
            [JsonProperty("uf_crm_1633374013", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("uf_crm_1633374013")]
            public bool UfCrm1633374013 { get; set; }
            [JsonProperty("source_description", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("source_description")]
            public string? SourceDescription { get; set; }
            [JsonProperty("uf_crm_1633367397", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("uf_crm_1633367397")]
            public string? UfCrm1633367397 { get; set; }
            [JsonProperty("uf_crm_1635799855", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("uf_crm_1635799855")]
            public string? UfCrm1635799855 { get; set; }
            [JsonProperty("uf_crm_1633366980", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("uf_crm_1633366980")]
            public string? UfCrm1633366980 { get; set; }
            [JsonProperty("uf_crm_1633429703", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("uf_crm_1633429703")]
            public string? UfCrm1633429703 { get; set; }
            [JsonProperty("uf_crm_1633373781", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("uf_crm_1633373781")]
            public string? UfCrm1633373781 { get; set; }
            [JsonProperty("kanban_stage_id", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("kanban_stage_id")]
            public int KanbanStageId { get; set; }
        }
        [XmlRoot("Deals")]
        public class Deal
        {
            [XmlElement("DealData")]
            [JsonProperty("data", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("data")]
            public List<DealData>? Data { get; set; }
            [JsonProperty("links", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("links")]
            public Link? Links { get; set; }
            [JsonProperty("meta", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("meta")]
            public Meta? Meta { get; set; }
        }
        #endregion
        #region Lead
        public class LeadData
        {
            [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("id")]
            public int Id { get; set; }
            [JsonProperty("created_at", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("created_at")]
            public int CreatedAt { get; set; }
            [JsonProperty("updated_at", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("updated_at")]
            public int UpdatedAt { get; set; }
            [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("title")]
            public string? Title { get; set; }
            [JsonProperty("owner", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("owner")]
            public int Owner { get; set; }
            [JsonProperty("created_by", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("created_by")]
            public int CreatedBy { get; set; }
            [JsonProperty("changed_by", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("changed_by")]
            public int ChangedBy { get; set; }
            [JsonProperty("converted", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("converted")]
            public bool Converted { get; set; }
            [JsonProperty("amount_of_the_deal", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("amount_of_the_deal")]
            public AmountOfTheDeal? AmountOfTheDeal { get; set; }
            [JsonProperty("contacts", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("contacts")]
            public List<Contacts>? Contacts { get; set; }
            [JsonProperty("companies", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("companies")]
            public List<Companies>? Companies { get; set; }
            [JsonProperty("utm_source", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("utm_source")]
            public string? UtmSource { get; set; }
            [JsonProperty("utm_medium", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("utm_medium")]
            public string? UtmMedium { get; set; }
            [JsonProperty("utm_campaign", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("utm_campaign")]
            public string? UtmCampaign { get; set; }
            [JsonProperty("utm_content", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("utm_content")]
            public string? UtmContent { get; set; }
            [JsonProperty("utm_term", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("utm_term")]
            public string? UtmTerm { get; set; }
            [JsonProperty("comments", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("comments")]
            public string? Comments { get; set; }
            [JsonProperty("source", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("source")]
            public List<Source>? Source { get; set; }
            [JsonProperty("deal_label", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("deal_label")]
            public List<Label>? DealLabel { get; set; }
            [JsonProperty("kanban_status", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("kanban_status")]
            public string? KanbanStatus { get; set; }
            [JsonProperty("kanban_reason_id", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("kanban_reason_id")]
            public int KanbanReasonId { get; set; }
            [JsonProperty("uf_crm_1635844186", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("uf_crm_1635844186")]
            public string? UfCrm1635844186 { get; set; }
            [JsonProperty("uf_crm_1643976907290", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("uf_crm_1643976907290")]
            public List<Label>? UfCrm1643976907290 { get; set; }
            [JsonProperty("uf_crm_1633366687", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("uf_crm_1633366687")]
            public string? UfCrm1633366687 { get; set; }
            [JsonProperty("uf_crm_1633430326", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("uf_crm_1633430326")]
            public string? UfCrm1633430326 { get; set; }
            [JsonProperty("uf_crm_1635613706", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("uf_crm_1635613706")]
            public bool UfCrm1635613706 { get; set; }
            [JsonProperty("probability", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("probability")]
            public string? Probability { get; set; }
            [JsonProperty("uf_crm_1633366883", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("uf_crm_1633366883")]
            public string? UfCrm1633366883 { get; set; }
            [JsonProperty("uf_crm_1682054017546", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("uf_crm_1682054017546")]
            public string? UfCrm1682054017546 { get; set; }
            [JsonProperty("uf_crm_1633429677", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("uf_crm_1633429677")]
            public string? UfCrm1633429677 { get; set; }
            [JsonProperty("additional_info", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("additional_info")]
            public string? AdditionalInfo { get; set; }
            [JsonProperty("uf_crm_1633367478", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("uf_crm_1633367478")]
            public string? UfCrm1633367478 { get; set; }
            [JsonProperty("uf_crm_1633366948", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("uf_crm_1633366948")]
            public string? UfCrm1633366948 { get; set; }
            [JsonProperty("uf_crm_1633635449", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("uf_crm_1633635449")]
            public string? UfCrm1633635449 { get; set; }
            [JsonProperty("uf_crm_1638006384173", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("uf_crm_1638006384173")]
            public string? UfCrm1638006384173 { get; set; }
            [JsonProperty("uf_crm_1633366773", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("uf_crm_1633366773")]
            public string? UfCrm1633366773 { get; set; }
            [JsonProperty("uf_crm_1633367088", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("uf_crm_1633367088")]
            public string? UfCrm1633367088 { get; set; }
            [JsonProperty("uf_crm_1633374013", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("uf_crm_1633374013")]
            public bool UfCrm1633374013 { get; set; }
            [JsonProperty("source_description", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("source_description")]
            public string? SourceDescription { get; set; }
            [JsonProperty("uf_crm_1633367397", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("uf_crm_1633367397")]
            public string? UfCrm1633367397 { get; set; }
            [JsonProperty("uf_crm_1635799855", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("uf_crm_1635799855")]
            public string? UfCrm1635799855 { get; set; }
            [JsonProperty("uf_crm_1633366980", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("uf_crm_1633366980")]
            public string? UfCrm1633366980 { get; set; }
            [JsonProperty("uf_crm_1633429703", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("uf_crm_1633429703")]
            public string? UfCrm1633429703 { get; set; }
            [JsonProperty("uf_crm_1633373781", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("uf_crm_1633373781")]
            public string? UfCrm1633373781 { get; set; }
            [JsonProperty("kanban_stage_id", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("kanban_stage_id")]
            public int KanbanStageId { get; set; }
        }
        [XmlRoot("Leads")]
        public class Lead
        {
            [XmlElement("LeadData")]
            [JsonProperty("data", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("data")]
            public List<LeadData>? Data { get; set; }
            [JsonProperty("links", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("links")]
            public Link? Links { get; set; }
            [JsonProperty("meta", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("meta")]
            public Meta? Meta { get; set; }
        }
        #endregion
        #region Call
        public class CallData
        {
            [JsonProperty("id")]
            [JsonPropertyName("id")]
            public int? Id { get; set; }
            [JsonProperty("task_id")]
            [JsonPropertyName("task_id")]
            public int? TaskId { get; set; }
            [JsonProperty("contact_id")]
            [JsonPropertyName("contact_id")]
            public int? ContactId { get; set; }
            [JsonProperty("company_id")]
            [JsonPropertyName("company_id")]
            public int? CompanyId { get; set; }
            [JsonProperty("deal_id")]
            [JsonPropertyName("deal_id")]
            public string? DealId { get; set; }
            [JsonProperty("lead_id")]
            [JsonPropertyName("lead_id")]
            public int? LeadId { get; set; }
            [JsonProperty("entity_table")]
            [JsonPropertyName("entity_table")]
            public string? EntityTable { get; set; }
            [JsonProperty("subject")]
            [JsonPropertyName("subject")]
            public string? Subject { get; set; }
            [JsonProperty("call_type")]
            [JsonPropertyName("call_type")]
            public string? CallType { get; set; }
            [JsonProperty("ended_call_status")]
            [JsonPropertyName("ended_call_status")]
            public string? EndedCallStatus { get; set; }
            [JsonProperty("from")]
            [JsonPropertyName("from")]
            public string? From { get; set; }
            [JsonProperty("to")]
            [JsonPropertyName("to")]
            public string? To { get; set; }
            [JsonProperty("begin_time")]
            [JsonPropertyName("begin_time")]
            public int? BeginTime { get; set; }
            [JsonProperty("end_time")]
            [JsonPropertyName("end_time")]
            public int? EndTime { get; set; }
            [JsonProperty("duration")]
            [JsonPropertyName("duration")]
            public int? Duration { get; set; }
            [JsonProperty("call_record_link")]
            [JsonPropertyName("call_record_link")]
            public string? CallRecordLink { get; set; }
            [JsonProperty("call_record_file")]
            [JsonPropertyName("call_record_file")]
            public object? CallRecordFile { get; set; }
            [JsonProperty("note")]
            [JsonPropertyName("note")]
            public string? Comment { get; set; }
            [JsonProperty("integration_code")]
            [JsonPropertyName("integration_code")]
            public string? IntegrationCode { get; set; }
            [JsonProperty("external_id")]
            [JsonPropertyName("external_id")]
            public string? ExternalId { get; set; }
            [JsonProperty("tmp_id")]
            [JsonPropertyName("tmp_id")]
            public string? TmpId { get; set; }
            [JsonProperty("contacts")]
            [JsonPropertyName("contacts")]
            public List<Contacts>? Contacts { get; set; }
            [JsonProperty("companies")]
            [JsonPropertyName("companies")]
            public List<Companies>? Companies { get; set; }
            [JsonProperty("employees")]
            [JsonPropertyName("employees")]
            public List<int>? Employees { get; set; }
            [JsonProperty("leads")]
            [JsonPropertyName("leads")]
            public List<CallLead>? Leads { get; set; }
            [JsonProperty("tasks")]
            [JsonPropertyName("tasks")]
            public CallTasks? Tasks { get; set; }
        }
        public class CallLead
        {
            [JsonProperty("id")]
            [JsonPropertyName("id")]
            public int? Id { get; set; }
            [JsonProperty("title")]
            [JsonPropertyName("title")]
            public string? Title { get; set; }
        }
        [XmlRoot("Calls")]
        public class Calls
        {
            [XmlElement("CallData")]
            [JsonProperty("data")]
            [JsonPropertyName("data")]
            public List<CallData>? Data { get; set; }
            [JsonProperty("links")]
            [JsonPropertyName("links")]
            public Link? Links { get; set; }
            [JsonProperty("meta")]
            [JsonPropertyName("meta")]
            public Meta? Meta { get; set; }
        }
        public class CallTasks
        {
            [JsonProperty("id")]
            [JsonPropertyName("id")]
            public int? Id { get; set; }
            [JsonProperty("title")]
            [JsonPropertyName("title")]
            public string? Title { get; set; }
        }


        #endregion
        #endregion

        #region PERFECTUM
        #region staff
        public class StuffCustomFields
        {
            [JsonProperty("staff", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("staff")]
            public Staff? Staff { get; set; }
        }
        public class StuffDatum
        {
            [JsonProperty("staffid", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("staffid")]
            public string? Staffid { get; set; }
            [JsonProperty("email", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("email")]
            public string? Email { get; set; }
            [JsonProperty("firstname", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("firstname")]
            public string? Firstname { get; set; }
            [JsonProperty("lastname", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("lastname")]
            public string? Lastname { get; set; }
            [JsonProperty("facebook", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("facebook")]
            public string? Facebook { get; set; }
            [JsonProperty("linkedin", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("linkedin")]
            public string? Linkedin { get; set; }
            [JsonProperty("phonenumber", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("phonenumber")]
            public string? Phonenumber { get; set; }
            [JsonProperty("skype", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("skype")]
            public string? Skype { get; set; }
            [JsonProperty("telegram", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("telegram")]
            public string? Telegram { get; set; }
            [JsonProperty("password", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("password")]
            public string? Password { get; set; }
            [JsonProperty("datecreated", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("datecreated")]
            public string? Datecreated { get; set; }
            [JsonProperty("last_ip", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("last_ip")]
            public string? LastIp { get; set; }
            [JsonProperty("last_login", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("last_login")]
            public string? LastLogin { get; set; }
            [JsonProperty("last_activity", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("last_activity")]
            public string? LastActivity { get; set; }
            [JsonProperty("last_active_time", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("last_active_time")]
            public string? LastActiveTime { get; set; }
            [JsonProperty("last_password_change", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("last_password_change")]
            public string? LastPasswordChange { get; set; }
            [JsonProperty("new_pass_key", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("new_pass_key")]
            public object? NewPassKey { get; set; }
            [JsonProperty("new_pass_key_requested", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("new_pass_key_requested")]
            public object? NewPassKeyRequested { get; set; }
            [JsonProperty("admin", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("admin")]
            public string? Admin { get; set; }
            [JsonProperty("role", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("role")]
            public string? Role { get; set; }
            [JsonProperty("active", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("active")]
            public string? Active { get; set; }
            [JsonProperty("default_language", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("default_language")]
            public string? DefaultLanguage { get; set; }
            [JsonProperty("direction", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("direction")]
            public string? Direction { get; set; }
            [JsonProperty("media_path_slug", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("media_path_slug")]
            public string? MediaPathSlug { get; set; }
            [JsonProperty("is_not_staff", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("is_not_staff")]
            public string? IsNotStaff { get; set; }
            [JsonProperty("hourly_rate", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("hourly_rate")]
            public string? HourlyRate { get; set; }
            [JsonProperty("email_signature", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("email_signature")]
            public string? EmailSignature { get; set; }
            [JsonProperty("birthday", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("birthday")]
            public string? Birthday { get; set; }
            [JsonProperty("internal_phonenumber", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("internal_phonenumber")]
            public string? InternalPhonenumber { get; set; }
            [JsonProperty("credit_card", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("credit_card")]
            public string? CreditCard { get; set; }
            [JsonProperty("email_login", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("email_login")]
            public string? EmailLogin { get; set; }
            [JsonProperty("email_password", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("email_password")]
            public string? EmailPassword { get; set; }
            [JsonProperty("email_client_views", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("email_client_views")]
            public string? EmailClientViews { get; set; }
            [JsonProperty("edited_profile", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("edited_profile")]
            public string? EditedProfile { get; set; }
            [JsonProperty("search_sections", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("search_sections")]
            public string? SearchSections { get; set; }
            [JsonProperty("dateupdated", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("dateupdated")]
            public string? Dateupdated { get; set; }
            [JsonProperty("custom_fields", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("custom_fields")]
            public List<StuffCustomFields>? CustomFields { get; set; }
        }
        public class PerfectumStuff
        {
            [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("status")]
            public bool Status { get; set; }
            [JsonProperty("message", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("message")]
            public string? Message { get; set; }
            [JsonProperty("data", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("data")]
            public List<StuffDatum>? Data { get; set; }
        }
        public class Staff
        {
            [JsonProperty("57", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("57")]
            public string? Job_Title { get; set; }
        }
        #endregion
        #region client
        public class ResponseWhenClientWasAdded
        {
            [JsonPropertyName("status")]
            public bool? Status { get; set; }
            [JsonPropertyName("message")]
            public string? Message { get; set; }
            [JsonPropertyName("id")]
            public int Id { get; set; }
        }
        public class ClientCustomers
        {
            [JsonProperty("10", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("10")]
            public string? ShareLink { get; set; }
            [JsonProperty("11", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("11")]
            public string? Comment { get; set; }
        }
        public class ClientCustomFields
        {
            [JsonProperty("customers", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("customers")]
            public ClientCustomers? Customers { get; set; }
            [JsonProperty("entities", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("entities")]
            public ClientEntities? Entities { get; set; }
        }
        public class ClientEntities
        {
            [JsonProperty("2", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("2")]
            public string? _2 { get; set; }

            [JsonProperty("3", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("3")]
            public string? _3 { get; set; }

            [JsonProperty("4", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("4")]
            public string? _4 { get; set; }

            [JsonProperty("5", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("5")]
            public string? _5 { get; set; }

            [JsonProperty("6", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("6")]
            public string? _6 { get; set; }

            [JsonProperty("7", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("7")]
            public string? _7 { get; set; }

            [JsonProperty("8", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("8")]
            public string? _8 { get; set; }

            [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("name")]
            public string? Name { get; set; }

            [JsonProperty("info", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("info")]
            public string? Info { get; set; }

            [JsonProperty("is_default", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("is_default")]
            public string? IsDefault { get; set; }

            [JsonProperty("billing_city", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("billing_city")]
            public string? BillingCity { get; set; }

            [JsonProperty("billing_state", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("billing_state")]
            public string? BillingState { get; set; }

            [JsonProperty("billing_zip", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("billing_zip")]
            public string? BillingZip { get; set; }

            [JsonProperty("billing_country", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("billing_country")]
            public string? BillingCountry { get; set; }

            [JsonProperty("billing_street", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("billing_street")]
            public string? BillingStreet { get; set; }

            [JsonProperty("shipping_street", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("shipping_street")]
            public string? ShippingStreet { get; set; }

            [JsonProperty("shipping_city", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("shipping_city")]
            public string? ShippingCity { get; set; }

            [JsonProperty("shipping_state", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("shipping_state")]
            public string? ShippingState { get; set; }

            [JsonProperty("shipping_zip", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("shipping_zip")]
            public string? ShippingZip { get; set; }

            [JsonProperty("shipping_country", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("shipping_country")]
            public string? ShippingCountry { get; set; }

            [JsonProperty("custom_fields", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("custom_fields")]
            public ClientCustomFields? CustomFields { get; set; }
        }
        public class Client
        {
            [JsonProperty("userid", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("userid")]
            public string? Userid { get; set; }
            [JsonProperty("company", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("company")]
            public string? Company { get; set; }
            [JsonProperty("phonenumber", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("phonenumber")]
            public string? Phonenumber { get; set; }
            [JsonProperty("email", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("email")]
            public string? EmailCompany { get; set; }
            [JsonProperty("vat", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("vat")]
            public object? Vat { get; set; }
            [JsonProperty("website", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("website")]
            public string? Website { get; set; }
            [JsonProperty("groups_in", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("groups_in")]
            public List<string>? GroupsIn { get; set; }
            [JsonProperty("category", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("category")]
            public string? Category { get; set; }
            [JsonProperty("discount_group", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("discount_group")]
            public string? DiscountGroup { get; set; }
            [JsonProperty("default_currency", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("default_currency")]
            public string? DefaultCurrency { get; set; }
            [JsonProperty("default_language", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("default_language")]
            public string? DefaultLanguage { get; set; }
            [JsonProperty("address", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("address")]
            public string? Address { get; set; }
            [JsonProperty("city", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("city")]
            public string? City { get; set; }
            [JsonProperty("state", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("state")]
            public string? State { get; set; }
            [JsonProperty("zip", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("zip")]
            public string? Zip { get; set; }
            [JsonProperty("country", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("country")]
            public string? Country { get; set; }
            [JsonProperty("billing_street", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("billing_street")]
            public string? BillingStreet { get; set; }
            [JsonProperty("billing_city", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("billing_city")]
            public string? BillingCity { get; set; }
            [JsonProperty("billing_state", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("billing_state")]
            public string? BillingState { get; set; }
            [JsonProperty("billing_zip", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("billing_zip")]
            public string? BillingZip { get; set; }
            [JsonProperty("billing_country", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("billing_country")]
            public string? BillingCountry { get; set; }
            [JsonProperty("shipping_street", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("shipping_street")]
            public string? ShippingStreet { get; set; }
            [JsonProperty("shipping_city", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("shipping_city")]
            public string? ShippingCity { get; set; }
            [JsonProperty("shipping_state", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("shipping_state")]
            public string? ShippingState { get; set; }
            [JsonProperty("shipping_zip", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("shipping_zip")]
            public string? ShippingZip { get; set; }
            [JsonProperty("shipping_country", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("shipping_country")]
            public string? ShippingCountry { get; set; }
            [JsonProperty("custom_fields", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("custom_fields")]
            public ClientCustomFields? CustomFields { get; set; }
            [JsonProperty("customer_admins", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("customer_admins")]
            public List<string>? CustomerAdmins { get; set; }
            [JsonProperty("entities", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("entities")]
            public List<ClientEntities>? Entities { get; set; }
        }
        public class ClientFromPerfect
        {
            [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("status")]
            public bool Status { get; set; }

            [JsonProperty("message", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("message")]
            public string? Message { get; set; }

            [JsonProperty("data", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("data")]
            public Client? Client { get; set; }
        }
        #endregion
        #region contact
        public class ClientContacts
        {
            [JsonProperty("15", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("15")]
            public string? _15 { get; set; }
            [JsonProperty("16", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("16")]
            public string? _16 { get; set; }
        }
        public class ContactCustomFields
        {
            [JsonProperty("contacts", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("contacts")]
            public ClientContacts? Contacts { get; set; }
        }
        public class ClientContactToConvert
        {
            [JsonProperty("userid", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("userid")]
            public string? Userid { get; set; }
            [JsonProperty("firstname", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("firstname")]
            public string? Firstname { get; set; }
            [JsonProperty("lastname", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("lastname")]
            public string? Lastname { get; set; }
            [JsonProperty("patronymic", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("patronymic")]
            public string? Patronymic { get; set; }
            [JsonProperty("profile_image", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("profile_image")]
            public string? ProfileImage { get; set; }
            [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("title")]
            public string? Title { get; set; }
            [JsonProperty("email", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("email")]
            public string? Email { get; set; }
            [JsonProperty("email_additional", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("email_additional")]
            public string? EmailAdditional { get; set; }
            [JsonProperty("phonenumber", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("phonenumber")]
            public string? Phonenumber { get; set; }
            [JsonProperty("phonenumber_additional", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("phonenumber_additional")]
            public string? PhonenumberAdditional { get; set; }
            [JsonProperty("gender", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("gender")]
            public string? Gender { get; set; }
            [JsonProperty("birthday", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("birthday")]
            public string? Birthday { get; set; }
            [JsonProperty("password", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("password")]
            public string? Password { get; set; }
            [JsonProperty("is_primary", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("is_primary")]
            public string? IsPrimary { get; set; }
            [JsonProperty("active", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("active")]
            public string? Active { get; set; }
            [JsonProperty("donotsendwelcomeemail", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("donotsendwelcomeemail")]
            public string? Donotsendwelcomeemail { get; set; }
            [JsonProperty("permissions", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("permissions")]
            public List<string>? Permissions { get; set; }
            [JsonProperty("invoice_emails", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("invoice_emails")]
            public string? InvoiceEmails { get; set; }
            [JsonProperty("project_emails", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("project_emails")]
            public string? ProjectEmails { get; set; }
            [JsonProperty("ticket_emails", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("ticket_emails")]
            public string? TicketEmails { get; set; }
            [JsonProperty("task_emails", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("task_emails")]
            public string? TaskEmails { get; set; }
            [JsonProperty("contract_emails", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("contract_emails")]
            public string? ContractEmails { get; set; }
            [JsonProperty("proposal_emails", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("proposal_emails")]
            public string? ProposalEmails { get; set; }
            [JsonProperty("custom_fields", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("custom_fields")]
            public ContactCustomFields? CustomFields { get; set; }
        }
        #endregion
        #region rekvezit
        public class RekvezitCustomFields
        {
            [JsonProperty("entities", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("entities")]
            public RekvezitEntities? Entities { get; set; }
        }
        public class RekvezitEntities
        {
            [JsonProperty("2", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("2")]
            public string? _2 { get; set; }
            [JsonProperty("3", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("3")]
            public string? _3 { get; set; }
            [JsonProperty("4", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("4")]
            public string? _4 { get; set; }
            [JsonProperty("5", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("5")]
            public string? _5 { get; set; }
            [JsonProperty("6", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("6")]
            public string? _6 { get; set; }
            [JsonProperty("7", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("7")]
            public string? _7 { get; set; }
            [JsonProperty("8", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("8")]
            public string? _8 { get; set; }
        }
        public class RekvezitToClientById
        {
            [JsonProperty("client_id", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("client_id")]
            public string? ClientId { get; set; }
            [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("name")]
            public string? Name { get; set; }
            [JsonProperty("is_default", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("is_default")]
            public string? IsDefault { get; set; }
            [JsonProperty("info", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("info")]
            public string? Info { get; set; }
            [JsonProperty("billing_country", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("billing_country")]
            public string? BillingCountry { get; set; }
            [JsonProperty("billing_state", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("billing_state")]
            public string? BillingState { get; set; }
            [JsonProperty("billing_zip", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("billing_zip")]
            public string? BillingZip { get; set; }
            [JsonProperty("billing_city", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("billing_city")]
            public string? BillingCity { get; set; }
            [JsonProperty("billing_street", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("billing_street")]
            public string? BillingStreet { get; set; }
            [JsonProperty("shipping_country", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("shipping_country")]
            public string? ShippingCountry { get; set; }
            [JsonProperty("shipping_state", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("shipping_state")]
            public string? ShippingState { get; set; }
            [JsonProperty("shipping_zip", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("shipping_zip")]
            public string? ShippingZip { get; set; }
            [JsonProperty("shipping_city", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("shipping_city")]
            public string? ShippingCity { get; set; }
            [JsonProperty("shipping_street", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("shipping_street")]
            public string? ShippingStreet { get; set; }
            [JsonProperty("custom_fields", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("custom_fields")]
            public RekvezitCustomFields? CustomFields { get; set; }
        }
        #endregion
        #region lead
        public class ResponseLead
        {
            [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("status")]
            public bool Status { get; set; }

            [JsonProperty("message", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("message")]
            public string? Message { get; set; }

            [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("id")]
            public int Id { get; set; }
        }
        public class LeadCustomFields
        {
            [JsonProperty("leads", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("leads")]
            public Leads? Leads { get; set; }
        }
        public class Leads
        {
            [JsonProperty("18", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("18")]
            public string? _18 { get; set; }
            [JsonProperty("20", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("20")]
            public string? _20 { get; set; }
        }
        public class LeadPerfectum
        {
            [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("type")]
            public int? Type { get; set; }
            [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("status")]
            public string? Status { get; set; }
            [JsonProperty("display_name", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("display_name")]
            public string? DisplayName { get; set; }
            [JsonProperty("assigned", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("assigned")]
            public string? Assigned { get; set; }
            [JsonProperty("source", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("source")]
            public string? Source { get; set; }
            [JsonProperty("client_id", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("client_id")]
            public string? ClientId { get; set; }
            [JsonProperty("contact_id", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("contact_id")]
            public string? ContactId { get; set; }
            [JsonProperty("utm", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("utm")]
            public string? Utm { get; set; }
            [JsonProperty("tags", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("tags")]
            public List<string>? Tags { get; set; }
            [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("name")]
            public string? Name { get; set; }
            [JsonProperty("surname", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("surname")]
            public string? Surname { get; set; }
            [JsonProperty("patronymic", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("patronymic")]
            public string? Patronymic { get; set; }
            [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("title")]
            public string? Title { get; set; }
            [JsonProperty("email", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("email")]
            public string? Email { get; set; }
            [JsonProperty("email_additional", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("email_additional")]
            public string? EmailAdditional { get; set; }
            [JsonProperty("instagram", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("instagram")]
            public string? Instagram { get; set; }
            [JsonProperty("whatsapp", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("whatsapp")]
            public string? Whatsapp { get; set; }
            [JsonProperty("telegram", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("telegram")]
            public string? Telegram { get; set; }
            [JsonProperty("viber", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("viber")]
            public string? Viber { get; set; }
            [JsonProperty("website", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("website")]
            public string? Website { get; set; }
            [JsonProperty("phonenumber", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("phonenumber")]
            public string? Phonenumber { get; set; }
            [JsonProperty("phonenumber_additional", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("phonenumber_additional")]
            public string? PhonenumberAdditional { get; set; }
            [JsonProperty("company", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("company")]
            public string? Company { get; set; }
            [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("description")]
            public string? Description { get; set; }
            [JsonProperty("address", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("address")]
            public string? Address { get; set; }
            [JsonProperty("city", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("city")]
            public string? City { get; set; }
            [JsonProperty("country", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("country")]
            public string? Country { get; set; }
            [JsonProperty("zip", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("zip")]
            public string? Zip { get; set; }
            [JsonProperty("default_language", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("default_language")]
            public string? DefaultLanguage { get; set; }
            [JsonProperty("is_public", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("is_public")]
            public string? IsPublic { get; set; }
            [JsonProperty("contacted_today", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("contacted_today")]
            public string? ContactedToday { get; set; }
            [JsonProperty("custom_fields", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("custom_fields")]
            public LeadCustomFields? CustomFields { get; set; }
        }
        #endregion
        #region task
        public class TaskCustomFields
        {
            [JsonProperty("tasks", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("tasks")]
            public Tasks? Tasks { get; set; }
        }
        public class PerefectumTask
        {
            [JsonProperty("billable", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("billable")]
            public string? Billable { get; set; }
            [JsonProperty("is_public", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("is_public")]
            public string? IsPublic { get; set; }
            [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("name")]
            public string? Name { get; set; }
            [JsonProperty("startdate", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("startdate")]
            public string? Startdate { get; set; }
            [JsonProperty("duedate", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("duedate")]
            public string? Duedate { get; set; }
            [JsonProperty("priority", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("priority")]
            public string? Priority { get; set; }
            [JsonProperty("hourly_rate", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("hourly_rate")]
            public string? HourlyRate { get; set; }
            [JsonProperty("deadline_staff_active", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("deadline_staff_active")]
            public string? DeadlineStaffActive { get; set; }
            [JsonProperty("deadline_staff", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("deadline_staff")]
            public string? DeadlineStaff { get; set; }
            [JsonProperty("staff_assignee", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("staff_assignee")]
            public List<string>? StaffAssignee { get; set; }
            [JsonProperty("tags", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("tags")]
            public string? Tags { get; set; }
            [JsonProperty("rel_type", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("rel_type")]
            public string? RelType { get; set; }
            [JsonProperty("rel_id", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("rel_id")]
            public string? RelId { get; set; }
            [JsonProperty("staff_deadline", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("staff_deadline")]
            public List<StaffDeadline>? StaffDeadline { get; set; }
            [JsonProperty("custom_fields", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("custom_fields")]
            public TaskCustomFields? CustomFields { get; set; }
            [JsonProperty("repeat_every", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("repeat_every")]
            public string? RepeatEvery { get; set; }
            [JsonProperty("recurring", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("recurring")]
            public string? Recurring { get; set; }
            [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("description")]
            public string? Description { get; set; }
        }
        public class StaffDeadline
        {
            [JsonProperty("staff_id", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("staff_id")]
            public string? StaffId { get; set; }
            [JsonProperty("deadline", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("deadline")]
            public string? Deadline { get; set; }
        }
        public class Tasks
        {
            [JsonProperty("79", NullValueHandling = NullValueHandling.Ignore)]
            [JsonPropertyName("79")]
            public string? _79 { get; set; }
        }
        #endregion
        #endregion

        #region MIX USPACY
        public class TestMIX
        {
            #region public properties
            public CompanyData? CompanyData { get; set; }
            public ContactData? ContactData { get; set; }
            public DealData? DealData { get; set; }
            public LeadData? LeadData { get; set; }
            public TaskData? TaskData { get; set; }
            #endregion
            #region constructors
            public TestMIX(CompanyData _companyData, ContactData _contactData, DealData _dealData, LeadData _leadData, TaskData _taskData)
            {
                if (_companyData is null)
                {
                    Console.WriteLine($"нет данных в {nameof(_companyData)}");
                }
                else
                {
                    CompanyData = _companyData;
                }
                if (_contactData is null)
                {
                    Console.WriteLine($"нет данных в {nameof(_contactData)}");
                }
                else
                {
                    ContactData = _contactData;
                }
                if (_dealData is null)
                {
                    Console.WriteLine($"нет данных в {nameof(_dealData)}");
                }
                else
                {
                    DealData = _dealData;
                }
                if (_leadData is null)
                {
                    Console.WriteLine($"нет данных в {nameof(_leadData)}");
                }
                else
                {
                    LeadData = _leadData;
                }
                if (_taskData is null)
                {
                    Console.WriteLine($"нет данных в {nameof(_taskData)}");
                }
                else
                {
                    TaskData = _taskData;
                }
            }
            #endregion
            #region helpers
#pragma warning disable CS8603 // Possible null reference return.
            public CompanyData GetCompanyData() => CompanyData;
            public ContactData GetContactData() => ContactData;
            public DealData GetDealData() => DealData;
            public LeadData GetLeadData() => LeadData;
            public TaskData GetTaskData() => TaskData;
#pragma warning restore CS8603 // Possible null reference return.
            #endregion
        }
        #endregion
    }
}