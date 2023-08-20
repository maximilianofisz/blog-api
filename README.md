# blog-api
Simple Web API for dør.

Para levantar la api:
Clonarla, agregar las tablas SQL que estan adjuntas en el repo y agregar la conn string al appsettings.json

Para quien revise:
Lo bueno: Creo que llegue a plasmar mi estilo de desarrollo y logre implementar algunas tecnicas y patrones de diseño que considero "mis caballitos de batalla".
Lamentablemente, no tengo el tiempo que querria para implementar muchas cosas que creo seria valioso mostrar. Por lo tanto, voy a pasar a enumerarlas aquí y si tengo tiempo extra hoy intentare seguir con ellas.
  - Mapping, en el codigo actual no se ningun tipo de mappeo y normalmente configuraria autoMapper y crearia perfiles para cada entidad para hacer rapidamente mappeos entre entidades y sus DTOs.
  - EF concurrency checking, quedo a mitad de camino, elegí el metodo de guardar en base un hash de version del dato para no tener problemas en la concurrencia pero despues no agregue los chequeos en los metodos PUT.
  - Comentarios de Swagger, self explanatory.
  - Un controller entero, no tenia sentido sinkearle tiempo a eso porque era exactamente el mismo codigo que otro controller solo que para otra entidad.
  - Me faltaron operaciones un poco mas complejas que solo 'findsall' de la base. Esta creo que es la que mas me duele. Normalmente, yo usaria algun tipo de sistema de clases-filtros para poder pasarle las expresiones de LINQ a EF y así poder filtrar, ordenar y paginar.
  - Unit-Testing, de este voy a dejar un ejemplo aca de otro proyecto personal. Para dar contexto, es una clase para el batch de tests de una entidad que se llama 'Grupos' y esta el test relacionado con un metodo de la aplicacion que devuelve todos los grupos:

        public GroupsTests()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<GroupProfile>());
            this.mapper = new Mapper(config);
            this.context = A.Fake<MessagingContext>();
        }

        [Fact]
        public void GetGroups_ShouldReturnAllGroups()
        {
            // Arrange
            
            var platformUserRepo = A.Fake<IPlatformUserRepository>();

            RecipientsGroup fakeGroup1 = new RecipientsGroup { Id = 1, CreatedBy = "Maximiliano Fisz", CreatedDate = DateTime.UtcNow
            , Description = "My test group", Group = "valid json", Name = "My group" };

            RecipientsGroup fakeGroup2 = new RecipientsGroup { Id = 2, CreatedBy = "Maximiliano Fisz", CreatedDate = DateTime.UtcNow
            , Description = "My test group 2", Group = "valid json", Name = "My group 2" };

            List<RecipientsGroup> fakeGroups = new List<RecipientsGroup>();

            fakeGroups.Add(fakeGroup1);
            fakeGroups.Add(fakeGroup2);

            var recipientGroupRepo = A.Fake<IRecipientsGroupRepository>();
            
            A.CallTo(() => recipientGroupRepo.FindAll()).Returns(fakeGroups);

            var controller = new GroupsController(mapper, recipientGroupRepo, platformUserRepo, context);

            // Act

            var actionResult = controller.GetGroups();


            // Assert

            var result = actionResult.Result as OkObjectResult;
            var returnGroupsDTO = result.Value as IEnumerable<GroupDTO>;

            IEnumerable<GroupDTO> fakeGroupsDTO = mapper.Map<IEnumerable<GroupDTO>>(fakeGroups);

            var jsonFakeGroupsDTO = JsonConvert.SerializeObject(fakeGroupsDTO);
            var jsonReturnGroupsDTO = JsonConvert.SerializeObject(returnGroupsDTO);

            Assert.Equal(jsonFakeGroupsDTO, jsonReturnGroupsDTO);
        }
    }
