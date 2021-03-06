﻿using System;
using System.Collections.Generic;
using SolucionesARWebsite2.DataAccess.Interfaces;
using SolucionesARWebsite2.DataObjects;
using SolucionesARWebsite2.Models;
using SolucionesARWebsite2.Enumerations;
using SolucionesARWebsite2.ViewModels.Roles;

namespace SolucionesARWebsite2.Business.Management
{
    public class RolesManagement
    {
        #region Constants
        #endregion

        #region Properties
        #endregion

        #region Private Members

        private readonly IRolesRepository _rolesRepository;

        #endregion

        #region Constructors

        public RolesManagement(IRolesRepository rolesRepository)
        {
            _rolesRepository = rolesRepository;
        }

        #endregion

        #region Public Methods

        public Rol GetRol(int rolId)
        {
            return _rolesRepository.GetRol(rolId);
        }

        public List<Rol> GetRoles()
        {
            return _rolesRepository.GetRoles();
        }

        public List<Rol> GetRoles(SecurityContext securityContext)
        {
            var rolesList = new List<Rol>();

            switch ((UserRoles)securityContext.User.RoleId)
            {
                case UserRoles.Customer:
                case UserRoles.Manager:
                case UserRoles.Salesman:
                    rolesList = new List<Rol>
                                        {
                                            new Rol
                                                {
                                                    RolId = securityContext.User.RoleId,
                                                    Name = securityContext.User.Role
                                                }
                                        };
                    break;
                case UserRoles.SuperUser:
                case UserRoles.Administrator:
                    rolesList = _rolesRepository.GetAllRoles();
                    break;
            }

            return rolesList;
        }

        public void Save(EditViewModel editViewModel)
        {
            var rol = Map(editViewModel);

            if (editViewModel.RolId == 0)
            {
                AddRol(rol);
            }
            else
            {
                EditRol(rol);
            }
        }

        #endregion

        #region Private Methods

        private void AddRol(Rol rol)
        {
            rol.CreatedAt = DateTime.Now;
            rol.UpdatedAt = DateTime.Now;
            _rolesRepository.AddRol(rol);
        }

        private void EditRol(Rol rol)
        {
            rol.UpdatedAt = DateTime.Now;
            _rolesRepository.EditRol(rol);
        }

        private static Rol Map(EditViewModel editViewMode)
        {
            return new Rol
                       {
                           RolId = editViewMode.RolId,
                           Name = editViewMode.RolName.ToUpper(),
                       };
        }

        #endregion
    }
}