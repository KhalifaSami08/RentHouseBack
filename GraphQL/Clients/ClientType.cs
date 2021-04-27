﻿using Backend_RentHouse_Khalifa_Sami.Model;
using HotChocolate.Types;

namespace Backend_RentHouse_Khalifa_Sami.GraphQL.Clients
{
    public class ClientType : ObjectType<Client>
    {
        protected override void Configure(IObjectTypeDescriptor<Client> descriptor)
        {
            base.Configure(descriptor);
        }
    }
}