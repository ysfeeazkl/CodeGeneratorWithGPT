namespace CodeGeneratorWithGPT
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        string classTemplate = "using System;\r\nusing System.Collections.Generic;\r\nusing System.Linq;\r\nusing System.Reflection.Metadata;\r\nusing System.Text;\r\nusing System.Threading.Tasks;\r\nusing Beryque.Domain.Entities;\r\n\r\nnamespace Beryque.Application.Features.Commands.\"*....\"Commands\r\n{\r\n    public class Delete\"*....\"CommandHandler: IRequestHandler<Delete\"*....\"Command,Unit>\r\n    {\r\n        readonly private I\"*....\"Repository _\".....\"Repository;\r\n        readonly private IMapper _mapper;\r\n        public Delete\".....\"CommandHandler(I\"*....\"Repository \".....\"Repository, IMapper mapper)\r\n        {\r\n            _\".....\"Repository = \".....\"Repository;\r\n            _mapper = mapper;\r\n\r\n        }\r\n\r\n        public async Task<Unit> Handle(Delete\"*....\"Command request, CancellationToken cancellationToken)\r\n        {\r\n            var \".....\" = _mapper.Map<\"*....\">(request);\r\n            await _\".....\"Repository.ArchiveByIdAsync(request.Id);\r\n            return Unit.Value;\r\n        }\r\n\r\n\r\n    }\r\n}\"";
        string description = "Templetin bu. \".....\" ve \"*....\" olan yerleri User ile doldurmanı istiyorum. \"*....\" olan yerleri büyük harf ile \".....\"  olan yerleri küçük harfle başla";

        List<string> entities = new List<string>() {"Basket" ,
            "BasketItem" ,
            "Category",
            "Comment",
            "OperationClaim" ,
            "Option" ,
            "Order" ,
            "Product" ,
            "ProductAndCategory" ,
            "ProductPicture" ,
            "Report",
            "ReportAndCategory",
            "ReportPicture",
            "User" ,
            "UserAndOperationClaim" ,
            "UserToken"};


        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            MappingsGenerator();
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

        void MappingsGenerator()
        {
            foreach (var item in entities)
            {

                string entityName = item;
                string projectDirectory = @"C:\Users\yusuf\OneDrive\Belgeler\GitHub\beryque\backend\Business\Beryque.Application\Mapping";
                string targetDirectory = Path.Combine(projectDirectory, $"{entityName}Mappings");

                string fileName = $"{entityName}Profile.cs";


                if (!Directory.Exists(targetDirectory))
                {
                    Directory.CreateDirectory(targetDirectory);
                }

                string generatedCode = $@"
using Beryque.Application.Features.Commands.{entityName}Commands;
using Beryque.Domain.Entities;

namespace Beryque.Application.Mapping.{entityName}Mappings;

public class {entityName}Profile : Profile
{{
    public {entityName}Profile()
    {{
        CreateMap<Create{entityName}Command, {entityName}>();
        CreateMap<Delete{entityName}Command, {entityName}>();
        CreateMap<Update{entityName}Command, {entityName}>();
    }}
}}
            ";

                string filePath = Path.Combine(targetDirectory, fileName);
                File.WriteAllText(filePath, generatedCode);
                
            }
            Console.WriteLine("Bittis");
            Console.ReadKey();
        }
    }
}