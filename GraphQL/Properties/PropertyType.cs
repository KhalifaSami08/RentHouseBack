﻿using Backend_RentHouse_Khalifa_Sami.Model;
using HotChocolate.Types;

namespace Backend_RentHouse_Khalifa_Sami.GraphQL.Properties
{
    public class PropertyType : ObjectType<Property>
    {
        protected override void Configure(IObjectTypeDescriptor<Property> descriptor)
        {
            base.Configure(descriptor);
        }
    }
}