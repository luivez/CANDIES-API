using AutoMapper;
using WebApi.Dtos;
using WebApi.Entities;

namespace WebApi.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // User
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
            CreateMap<UserRegisterDto, User>();
            CreateMap<User, UserRegisterDto>();

            // Role
            CreateMap<Role, RoleDto>();
            CreateMap<RoleDto, Role>();

            // Page
            CreateMap<Page, PageDto>();
            CreateMap<PageDto, Page>();

            // UserRole
            CreateMap<UserRole, UserRoleDto>();
            CreateMap<UserRoleDto, UserRole>();

            // RolePage
            CreateMap<RolePage, RolePageDto>();
            CreateMap<RolePageDto, RolePage>();

            // Provider
            CreateMap<Provider, ProviderDto>();
            CreateMap<ProviderDto, Provider>();

            // Product
            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product>();

            // OperationProductEntry
            CreateMap<OperationProductEntry, OperationProductEntryDto>();
            CreateMap<OperationProductEntryDto, OperationProductEntry>();

            // OperationProductOutput
            CreateMap<OperationProductOutput, OperationProductOutputDto>();
            CreateMap<OperationProductOutputDto, OperationProductOutput>();

            // PurchaseOrder
            CreateMap<PurchaseOrder, PurchaseOrderDto>();
            CreateMap<PurchaseOrderDto, PurchaseOrder>();

            // PurchaseDetail
            CreateMap<PurchaseDetail, PurchaseDetailDto>();
            CreateMap<PurchaseDetailDto, PurchaseDetail>();

            // ProductType
            CreateMap<ProductType, ProductTypeDto>();
            CreateMap<ProductTypeDto, ProductType>();

            // StatusMachine
            CreateMap<StatusMachine, StatusMachineDto>();
            CreateMap<StatusMachineDto, StatusMachine>();

            // Machine
            CreateMap<Machine, MachineDto>();
            CreateMap<MachineDto, Machine>();

            // Person
            CreateMap<Person, PersonDto>();
            CreateMap<PersonDto, Person>();

            // Client
            CreateMap<Client, ClientDto>();
            CreateMap<ClientDto, Client>();

            // ClientMachine
            CreateMap<ClientMachine, ClientMachineDto>();
            CreateMap<ClientMachineDto, ClientMachine>();

            // Notification
            CreateMap<Notification, NotificationDto>();
            CreateMap<NotificationDto, Notification>();
        }
    }
}