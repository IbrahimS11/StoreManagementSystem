global using StoreManagementSystem.Models.Customers;
global using StoreManagementSystem.Models.Orders;
global using StoreManagementSystem.Models.Locations;
global using StoreManagementSystem.Models.Products;
global using StoreManagementSystem.Models.Suppliers;
global using StoreManagementSystem.Models.Inventories;
global using StoreManagementSystem.Data;

global using Microsoft.AspNetCore.Authentication.JwtBearer;
global using Microsoft.AspNetCore.Identity;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.IdentityModel.Tokens;
global using Microsoft.AspNetCore.Mvc;

global using StoreManagementSystem.Filters;
global using StoreManagementSystem.Identity;

global using StoreManagementSystem.Repositories.Interfaces;
global using StoreManagementSystem.Repositories.Interfaces.Inventories;
global using StoreManagementSystem.Repositories.Interfaces.Products;
global using StoreManagementSystem.Repositories.Interfaces.Suppliers;
global using StoreManagementSystem.Repositories.Interfaces.UnitOfWork;

global using StoreManagementSystem.Repositories.Implementations.Inventories;
global using StoreManagementSystem.Repositories.Implementations.Products;
global using StoreManagementSystem.Repositories.Implementations.Suppliers;
global using StoreManagementSystem.Repositories.Implementations.UnitOfWork;

global using StoreManagementSystem.Services.Interfaces.Account;
global using StoreManagementSystem.Services.Interfaces.Inventories;
global using StoreManagementSystem.Services.Interfaces.Products;

global using StoreManagementSystem.Services.Implementation.Account;
global using StoreManagementSystem.Services.Implementation.Inventories;
global using StoreManagementSystem.Services.Implementation.Products;

global using System.Text;


