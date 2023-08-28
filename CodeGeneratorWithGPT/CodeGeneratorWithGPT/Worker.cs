using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;

namespace CodeGeneratorWithGPT
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        string classTemplate = "using System;\r\nusing System.Collections.Generic;\r\nusing System.Linq;\r\nusing System.Reflection.Metadata;\r\nusing System.Text;\r\nusing System.Threading.Tasks;\r\nusing Beryque.Domain.Entities;\r\n\r\nnamespace Beryque.Application.Features.Commands.\"*....\"Commands\r\n{\r\n    public class Delete\"*....\"CommandHandler: IRequestHandler<Delete\"*....\"Command,Unit>\r\n    {\r\n        readonly private I\"*....\"Repository _\".....\"Repository;\r\n        readonly private IMapper _mapper;\r\n        public Delete\".....\"CommandHandler(I\"*....\"Repository \".....\"Repository, IMapper mapper)\r\n        {\r\n            _\".....\"Repository = \".....\"Repository;\r\n            _mapper = mapper;\r\n\r\n        }\r\n\r\n        public async Task<Unit> Handle(Delete\"*....\"Command request, CancellationToken cancellationToken)\r\n        {\r\n            var \".....\" = _mapper.Map<\"*....\">(request);\r\n            await _\".....\"Repository.ArchiveByIdAsync(request.Id);\r\n            return Unit.Value;\r\n        }\r\n\r\n\r\n    }\r\n}\"";
        string description = "Templetin bu. \".....\" ve \"*....\" olan yerleri User ile doldurmanı istiyorum. \"*....\" olan yerleri büyük harf ile \".....\"  olan yerleri küçük harfle başla";

        List<string> entities = new List<string>() {"Basket" ,
            "BasketItem" ,
            "Category" ,
            "OperationClaim" ,
            "Option" ,
            "Order" ,
            "Product" ,
            "ProductAndCategory" ,
            "ProductPicture" ,
            "Report" ,
            "User" ,
            "UserAndOperationClaim" ,
            "UserToken"};


        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            //GPT.gpt();
            //CreateHandlerCreated();

            TemplateCreate();
        }


        void test()
        {
            string generatedCode = @"
                // Your generated code here...
            ";

            string projectDirectory = "C:/app/project"; // Projenizin ana dizini
            string filePath = Path.Combine(projectDirectory, "beryque/application/features/commands/UserCommands/DeleteUserCommandHandler.cs");

            Directory.CreateDirectory(Path.GetDirectoryName(filePath)); // Gerektiğinde dizinleri oluştur
            File.WriteAllText(filePath, generatedCode);

            Console.WriteLine($"File '{filePath}' has been created.");
        }

        void TemplateCreate()
        {

            List<string> entities = new List<string>() {
    "Basket",
    "BasketItem",
    "Category",
    "OperationClaim",
    "Option",
    "Order",
    "Product",
    "ProductAndCategory",
    "ProductPicture",
    "Report",
    "User",
    "UserAndOperationClaim",
    "UserToken"
};

            List<ClassType> classTypes = new List<ClassType>();

            foreach (string entity in entities)
            {
                string template = $"using Beryque.Domain.Entities;\n\nnamespace Beryque.Application.Features.Commands.{entity}Commands\n{{\n    public class Create{entity}CommandHandler : IRequestHandler<Create{entity}Command, Unit>\n    {{\n        readonly private I{entity}Repository _{entity.ToLower()}Repository;\n        readonly private IMapper _mapper;\n\n        public Create{entity}CommandHandler(I{entity}Repository {entity.ToLower()}Repository, IMapper mapper)\n        {{\n            _{entity.ToLower()}Repository = {entity.ToLower()}Repository;\n            _mapper = mapper;\n        }}\n\n        public async Task<Unit> Handle(Create{entity}Command request, CancellationToken cancellationToken)\n        {{\n            var {entity.ToLower()} = _mapper.Map<{entity}>(request);\n            await _{entity.ToLower()}Repository.AddAsync({entity.ToLower()});\n            return Unit.Value;\n        }}\n    }}\n}}";

                classTypes.Add(new ClassType
                {
                    Folder = $"C:\\Users\\yazakli\\Documents\\GitHub\\beryque\\backend\\Business\\Beryque.Application\\Features\\Commands\\{entity}Commands",
                    Template = template,
                    FolderName = $"Create{entity}CommandHandler",
                    FileExtension = ".cs"
                });
            }

            string jsonResult = JsonSerializer.Serialize(classTypes, new JsonSerializerOptions { WriteIndented = true });
            Console.WriteLine(jsonResult);

        }

        void DeleteHandlerCreated()
        {
            string entityName = "UserAndOperationClaim";
            string projectDirectory = @"C:\Users\yusuf\OneDrive\Belgeler\GitHub\beryque\Business\Beryque.Application\Features\Commands";
            string targetDirectory = Path.Combine(projectDirectory, $"{entityName}Commands");
            string fileName = $"Delete{entityName}CommandHandler.cs";


            if (!Directory.Exists(targetDirectory))
            {
                Directory.CreateDirectory(targetDirectory);
            }

            string generatedCode = $@"
                using System;
                using System.Collections.Generic;
                using System.Linq;
                using System.Reflection.Metadata;
                using System.Text;
                using System.Threading.Tasks;
                using Beryque.Domain.Entities;
                using MediatR;

                namespace Beryque.Application.Features.Commands.{entityName}Commands
                {{
                    public class Delete{entityName}CommandHandler : IRequestHandler<Delete{entityName}Command, Unit>
                    {{
                        readonly private I{entityName}Repository _{entityName.ToLower()}Repository;
                        readonly private IMapper _mapper;

                        public Delete{entityName}CommandHandler(I{entityName}Repository {entityName.ToLower()}Repository, IMapper mapper)
                        {{
                            _{entityName.ToLower()}Repository = {entityName.ToLower()}Repository;
                            _mapper = mapper;
                        }}

                        public async Task<Unit> Handle(Delete{entityName}Command request, CancellationToken cancellationToken)
                        {{
                            var {entityName.ToLower()} = _mapper.Map<{entityName}>(request);
                            await _{entityName.ToLower()}Repository.ArchiveByIdAsync(request.Id);
                            return Unit.Value;
                        }}
                    }}
                }}
            ";

            string filePath = Path.Combine(targetDirectory, fileName);
            File.WriteAllText(filePath, generatedCode);

            Console.WriteLine($"File '{filePath}' has been created in the {entityName}Commands folder.");
            Console.ReadKey();
        }

        void CreateHandlerCreated()
        {
            List<string> entities = new List<string>() {"Basket" ,
            "BasketItem" ,
            "Category" ,
            "OperationClaim" ,
            "Option" ,
            "Order" ,
            "Product" ,
            "ProductAndCategory" ,
            "ProductPicture" ,
            "Report" ,
            "User" ,
            "UserAndOperationClaim" ,
            "UserToken"};
            foreach (var item in entities)
            {
                string entityName = item;
                //string projectDirectory = @"C:\Users\yusuf\OneDrive\Belgeler\GitHub\beryque\Business\Beryque.Application\Features\Commands";
                string projectDirectory = @"C:\Users\yazakli\Documents\GitHub\beryque\Business\Beryque.Application\Features\Commands\";
                string targetDirectory = Path.Combine(projectDirectory, $"{entityName}Commands");
                string Crud = "Create";
                string fileName = $"{Crud}{entityName}CommandHandler.cs";


                if (!Directory.Exists(targetDirectory))
                {
                    Directory.CreateDirectory(targetDirectory);
                }

                string generatedCode = $@"
                using System;
                using System.Collections.Generic;
                using System.Linq;
                using System.Reflection.Metadata;
                using System.Text;
                using System.Threading.Tasks;
                using Beryque.Domain.Entities;
                using MediatR;

                namespace Beryque.Application.Features.Commands.{entityName}Commands
                {{
                    public class {Crud}{entityName}CommandHandler : IRequestHandler<Delete{entityName}Command, Unit>
                    {{
                        readonly private I{entityName}Repository _{entityName.ToLower()}Repository;
                        readonly private IMapper _mapper;

                        public {Crud}{entityName}CommandHandler(I{entityName}Repository {entityName.ToLower()}Repository, IMapper mapper)
                        {{
                            _{entityName.ToLower()}Repository = {entityName.ToLower()}Repository;
                            _mapper = mapper;
                        }}

                        public async Task<Unit> Handle({Crud}{entityName}Command request, CancellationToken cancellationToken)
                        {{
                            var {entityName.ToLower()} = _mapper.Map<{entityName}>(request);
                            await _{entityName.ToLower()}Repository.AddAsync(request);
                            return Unit.Value;
                        }}
                    }}
                }}
            ";

                string filePath = Path.Combine(targetDirectory, fileName);
                File.WriteAllText(filePath, generatedCode);

                
            }

        }
    }

    public static class GPT
    {
        public static async void gpt()
        {
            string apiKey = "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";
            string prompt = "Selam gpt nasılsın'";

            using HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");

            string apiUrl = "https://api.openai.com/v1/engines/davinci-codex/completions";
            string requestBody = $"{{ \"prompt\": \"{prompt}\", \"max_tokens\": 50 }}";
            var content = new StringContent(requestBody, Encoding.UTF8, "application/json");

            var response = await client.PostAsync(apiUrl, content);
            string responseContent = await response.Content.ReadAsStringAsync();
            Console.WriteLine(responseContent);
        }
    }

    public class ClassType
    {
        public string Folder { get; set; } //dosyanın kaydedileceği dizin
        public string Template { get; set; } //dosya template i
        public string FolderName { get; set; } //classın isimi örneğin "CreateOperationClaimCommandHandler"
        public string FileExtension { get; set; } //Dosya uzantısı örneğin ".cs"
    }
}