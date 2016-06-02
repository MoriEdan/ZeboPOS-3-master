﻿using System.ComponentModel.Composition;
using Microsoft.Practices.Prism.MefExtensions.Modularity;
using Microsoft.Practices.Prism.Regions;
using Zebo.Localization.Properties;
using Zebo.Presentation.Common;
using Zebo.Presentation.Services.Common;
using Zebo.Services;

namespace Zebo.Modules.DepartmentModule
{
    [ModuleExport(typeof(DepartmentModule))]
    public class DepartmentModule : ModuleBase
    {
        private readonly IRegionManager _regionManager;
        private readonly IDepartmentService _departmentService;

        [ImportingConstructor]
        public DepartmentModule(IRegionManager regionManager, IDepartmentService departmentService)
        {
            _departmentService = departmentService;
            _regionManager = regionManager;
            AddDashboardCommand<DepartmentListViewModel>(Resources.Departments, Resources.Settings,20);
            PermissionRegistry.RegisterPermission(PermissionNames.ChangeDepartment, PermissionCategories.Department, Resources.CanChangeDepartment);

            foreach (var department in _departmentService.GetDepartments())
            {
                PermissionRegistry.RegisterPermission(PermissionNames.UseDepartment + department.Id, PermissionCategories.Department, department.Name);
            }
        }

        protected override void OnInitialization()
        {
            _regionManager.RegisterViewWithRegion(RegionNames.UserRegion, typeof(DepartmentSelectorView));
        }
    }
}