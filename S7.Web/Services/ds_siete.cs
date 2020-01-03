
namespace S7.Web.Services
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Data;
    using System.Linq;
    using System.ServiceModel.DomainServices.EntityFramework;
    using System.ServiceModel.DomainServices.Hosting;
    using System.ServiceModel.DomainServices.Server;
    using S7.Web.Models;


    // Implements application logic using the sieteEntidades context.
    // TODO: Add your application logic to these methods or in additional methods.
    // TODO: Wire up authentication (Windows/ASP.NET Forms) and uncomment the following to disable anonymous access
    // Also consider adding roles to restrict access as appropriate.
    // [RequiresAuthentication]
    [EnableClientAccess()]
    public class ds_siete : LinqToEntitiesDomainService<sieteEntidades>
    {
        ///// Customs By Lobo


        public IQueryable<c_tipo_incidencias_incidencias> Get_c_tipo_incidencias_incidencias()
        {


            var _inciencias = from a in ObjectContext.incidencias
                           join b in ObjectContext.tipos_incidencias on a.tip_inc_idn equals b.tip_inc_idn
                           orderby b.tip_inc_nombre, a.inc_nombre
                           select new c_tipo_incidencias_incidencias
                           {
                               inc_idn = a.inc_idn,
                               inc_nombre = a.inc_nombre,
                               tip_inc_nombre = b.tip_inc_nombre
                               
                           };



            return _inciencias;
        }
     
        
        
        public IQueryable<c_usuarios_empresas_cargos> Get_usuario_login(string usu_email, string usu_clave)
        {


            var _usuario = from a in ObjectContext.usuarios
                           join b in ObjectContext.empresas_usuarios_sedes on a.usu_idn equals b.usu_idn
                           where a.usu_email == usu_email && a.usu_clave == usu_clave
                           select new c_usuarios_empresas_cargos
                           {

                               usu_idn = a.usu_idn,
                               usu_email = a.usu_email,
                               usu_clave = a.usu_clave,
                               emp_usu_sed_idn = b.emp_usu_sed_idn

                           };



            return _usuario;
        }



        public IQueryable<procesos_gestiones_incidencias_saltos> Getprocesos_gestiones_incidencias_saltos_x_id(int pro_ges_inc_idn)
        {


            var _gestiones = from a in ObjectContext.procesos_gestiones_incidencias_saltos
                             where a.pro_ges_inc_idn == pro_ges_inc_idn
                             select a;

            return _gestiones;
        }




        public IQueryable<c_atenciones_procesos_incidencias_gestiones> Getc_atenciones_procesos_incidencias_gestiones(int ate_inc_idn)
        {



            var _gestiones = from a in ObjectContext.atenciones_procesos_incidencias
                             join b in ObjectContext.procesos_gestiones_incidencias on a.pro_ges_inc_idn equals b.pro_ges_inc_idn
                             join c in ObjectContext.procesos_incidencias on b.pro_inc_idn equals c.pro_inc_idn
                             join d in ObjectContext.gestiones_incindecias on b.ges_inc_idn equals d.ges_inc_idn
                             join e in ObjectContext.empresas_usuarios_sedes on a.emp_usu_sed_idn equals e.emp_usu_sed_idn
                             join f in ObjectContext.usuarios on e.usu_idn equals f.usu_idn

                             select new c_atenciones_procesos_incidencias_gestiones
                             {

                                 ate_pro_inc_idn = a.ate_pro_inc_idn,
                                 pro_inc_idn = c.pro_inc_idn,
                                 pro_inc_nombre = c.pro_inc_nombre,
                                 ges_inc_nombre = d.ges_inc_nombre,
                                 ate_pro_inc_fecha_ingreso = a.ate_pro_inc_fecha_ingreso,
                                 emp_usu_sed_idn = e.emp_usu_sed_idn,
                                 usu_nombres = f.usu_apellidos + " " + f.usu_nombres

                             };

            return _gestiones;
        }




        public IQueryable<c_procesos_gestiones_nombres> Getc_procesos_gestiones_nombres(int pro_inc_idn)
        {



            var _gestiones = from a in ObjectContext.procesos_gestiones_incidencias
                             join b in ObjectContext.procesos_incidencias on a.pro_inc_idn equals b.pro_inc_idn
                             join c in ObjectContext.gestiones_incindecias on a.ges_inc_idn equals c.ges_inc_idn
                             where a.pro_inc_idn == pro_inc_idn
                             select new c_procesos_gestiones_nombres
                             {

                                 pro_ges_inc_idn = a.pro_ges_inc_idn,
                                 nombre = c.ges_inc_nombre .Trim()

                             };

            return _gestiones;
        }


        public IQueryable<c_usuario_productos_nombres> Getc_usuario_productos_nombres(int usu_idn)
        {



            var _productos = from a in ObjectContext.usuarios_productos
                             join b in ObjectContext.productos on a.pro_idn equals b.pro_idn
                             where a.usu_idn == usu_idn
                             select new c_usuario_productos_nombres
                             {

                                 usu_pro_idn = a.usu_pro_idn,
                                 pro_nombre = b.pro_nombre

                             };

            return _productos;
        }


        public IQueryable<c_usuarios_nombre_cuenta_productos> c_usuarios_nombre_cuenta_productos_x_usu_apellidos(string criterio)
        {

            var _usuarios = from a in ObjectContext.usuarios
                            join b in ObjectContext.usuarios_productos on a.usu_idn equals b.usu_idn
                            where a.usu_apellidos.Contains(criterio)

                            group a by a.usu_idn into g
                            select new c_usuarios_nombre_cuenta_productos
                            {

                                usu_idn = g.Key,
                                usu_id_nacional = g.Select(x => x.usu_id_nacional).FirstOrDefault(),
                                nombre = g.Select(x => x.usu_apellidos + " " + x.usu_nombres).FirstOrDefault(),
                                contador = g.Count()

                            };



            return _usuarios;

        }





        public IQueryable<c_usuarios_nombre> Getc_usuarios_nombre()
        {


            var _usuarios = from a in ObjectContext.usuarios
                            join b in ObjectContext.empresas_usuarios_sedes on a.usu_idn equals b.usu_idn
                            join c in ObjectContext.cargos on b.car_idn equals c.car_idn

                            orderby a.usu_apellidos, a.usu_nombres
                            select new c_usuarios_nombre
                            {

                                emp_usu_sed_idn = b.emp_usu_sed_idn,
                                nombre = a.usu_apellidos + " " + a.usu_nombres + " - " + c.car_nombre

                            };

            return _usuarios;
        }

        public IQueryable<c_semaforo_parametros> Getc_semaforo_parametros()
        {


            var _semaforo = from a in ObjectContext.semaforo_periodos_evaluaciones
                            join b in ObjectContext.procesos_incidencias on a.pro_inc_idn equals b.pro_inc_idn
                            join c in ObjectContext.semaforos on a.sem_idn equals c.sem_idn
                            orderby a.pro_inc_idn, c.sem_idn
                            select new c_semaforo_parametros
                            {

                                sem_per_idn = a.sem_per_idn,
                                Proceso = b.pro_inc_nombre,
                                sem_color = c.sem_color,
                                sem_per_dias_desde = a.sem_per_dias_desde,
                                sem_per_dias_hasta = a.sem_per_dias_hasta



                            };



            return _semaforo;

        }





        public IQueryable<c_incidencias_usuarios> Getc_incidencias_usuarios(int emp_usu_sed_idn)
        {



            var _incidencias = from a in ObjectContext.atenciones_incidencias
                               join b in ObjectContext.usuarios_productos on a.usu_pro_idn equals b.usu_pro_idn
                               join c in ObjectContext.productos on b.pro_idn equals c.pro_idn
                               join d in ObjectContext.usuarios on b.usu_idn equals d.usu_idn
                               join e in ObjectContext.incidencias on a.inc_idn equals e.inc_idn
                               join f in ObjectContext.atenciones on a.ate_idn equals f.ate_idn
                               orderby a.ate_inc_fecha_ingreso descending
                               where f.emp_usu_sed_idn == emp_usu_sed_idn
                               select new c_incidencias_usuarios
                               {
                                   ate_inc_idn = a.ate_inc_idn,
                                   inc_nombre = e.inc_nombre,
                                   nombre = d.usu_apellidos + " " + d.usu_nombres,
                                   pro_nombre = c.pro_nombre,
                                   ate_inc_fecha_ingreso = a.ate_inc_fecha_ingreso

                               };

            return _incidencias;
        }
        //////
        //
        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'anos' query.
        public IQueryable<anos> GetAnos()
        {
            return this.ObjectContext.anos;
        }

        public void InsertAnos(anos anos)
        {
            if ((anos.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(anos, EntityState.Added);
            }
            else
            {
                this.ObjectContext.anos.AddObject(anos);
            }
        }

        public void UpdateAnos(anos currentanos)
        {
            this.ObjectContext.anos.AttachAsModified(currentanos, this.ChangeSet.GetOriginal(currentanos));
        }

        public void DeleteAnos(anos anos)
        {
            if ((anos.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(anos, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.anos.Attach(anos);
                this.ObjectContext.anos.DeleteObject(anos);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'atenciones' query.
        public IQueryable<atenciones> GetAtenciones()
        {
            return this.ObjectContext.atenciones;
        }

        public void InsertAtenciones(atenciones atenciones)
        {
            if ((atenciones.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(atenciones, EntityState.Added);
            }
            else
            {
                this.ObjectContext.atenciones.AddObject(atenciones);
            }
        }

        public void UpdateAtenciones(atenciones currentatenciones)
        {
            this.ObjectContext.atenciones.AttachAsModified(currentatenciones, this.ChangeSet.GetOriginal(currentatenciones));
        }

        public void DeleteAtenciones(atenciones atenciones)
        {
            if ((atenciones.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(atenciones, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.atenciones.Attach(atenciones);
                this.ObjectContext.atenciones.DeleteObject(atenciones);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'atenciones_incidencias' query.
        public IQueryable<atenciones_incidencias> GetAtenciones_incidencias()
        {
            return this.ObjectContext.atenciones_incidencias;
        }

        public void InsertAtenciones_incidencias(atenciones_incidencias atenciones_incidencias)
        {
            if ((atenciones_incidencias.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(atenciones_incidencias, EntityState.Added);
            }
            else
            {
                this.ObjectContext.atenciones_incidencias.AddObject(atenciones_incidencias);
            }
        }

        public void UpdateAtenciones_incidencias(atenciones_incidencias currentatenciones_incidencias)
        {
            this.ObjectContext.atenciones_incidencias.AttachAsModified(currentatenciones_incidencias, this.ChangeSet.GetOriginal(currentatenciones_incidencias));
        }

        public void DeleteAtenciones_incidencias(atenciones_incidencias atenciones_incidencias)
        {
            if ((atenciones_incidencias.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(atenciones_incidencias, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.atenciones_incidencias.Attach(atenciones_incidencias);
                this.ObjectContext.atenciones_incidencias.DeleteObject(atenciones_incidencias);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'atenciones_procesos_incidencias' query.
        public IQueryable<atenciones_procesos_incidencias> GetAtenciones_procesos_incidencias()
        {
            return this.ObjectContext.atenciones_procesos_incidencias;
        }

        public void InsertAtenciones_procesos_incidencias(atenciones_procesos_incidencias atenciones_procesos_incidencias)
        {
            if ((atenciones_procesos_incidencias.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(atenciones_procesos_incidencias, EntityState.Added);
            }
            else
            {
                this.ObjectContext.atenciones_procesos_incidencias.AddObject(atenciones_procesos_incidencias);
            }
        }

        public void UpdateAtenciones_procesos_incidencias(atenciones_procesos_incidencias currentatenciones_procesos_incidencias)
        {
            this.ObjectContext.atenciones_procesos_incidencias.AttachAsModified(currentatenciones_procesos_incidencias, this.ChangeSet.GetOriginal(currentatenciones_procesos_incidencias));
        }

        public void DeleteAtenciones_procesos_incidencias(atenciones_procesos_incidencias atenciones_procesos_incidencias)
        {
            if ((atenciones_procesos_incidencias.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(atenciones_procesos_incidencias, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.atenciones_procesos_incidencias.Attach(atenciones_procesos_incidencias);
                this.ObjectContext.atenciones_procesos_incidencias.DeleteObject(atenciones_procesos_incidencias);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'cargos' query.
        public IQueryable<cargos> GetCargos()
        {
            return this.ObjectContext.cargos;
        }

        public void InsertCargos(cargos cargos)
        {
            if ((cargos.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(cargos, EntityState.Added);
            }
            else
            {
                this.ObjectContext.cargos.AddObject(cargos);
            }
        }

        public void UpdateCargos(cargos currentcargos)
        {
            this.ObjectContext.cargos.AttachAsModified(currentcargos, this.ChangeSet.GetOriginal(currentcargos));
        }

        public void DeleteCargos(cargos cargos)
        {
            if ((cargos.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(cargos, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.cargos.Attach(cargos);
                this.ObjectContext.cargos.DeleteObject(cargos);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'empresas' query.
        public IQueryable<empresas> GetEmpresas()
        {
            return this.ObjectContext.empresas;
        }

        public void InsertEmpresas(empresas empresas)
        {
            if ((empresas.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(empresas, EntityState.Added);
            }
            else
            {
                this.ObjectContext.empresas.AddObject(empresas);
            }
        }

        public void UpdateEmpresas(empresas currentempresas)
        {
            this.ObjectContext.empresas.AttachAsModified(currentempresas, this.ChangeSet.GetOriginal(currentempresas));
        }

        public void DeleteEmpresas(empresas empresas)
        {
            if ((empresas.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(empresas, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.empresas.Attach(empresas);
                this.ObjectContext.empresas.DeleteObject(empresas);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'empresas_usuarios_sedes' query.
        public IQueryable<empresas_usuarios_sedes> GetEmpresas_usuarios_sedes()
        {
            return this.ObjectContext.empresas_usuarios_sedes;
        }

        public void InsertEmpresas_usuarios_sedes(empresas_usuarios_sedes empresas_usuarios_sedes)
        {
            if ((empresas_usuarios_sedes.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(empresas_usuarios_sedes, EntityState.Added);
            }
            else
            {
                this.ObjectContext.empresas_usuarios_sedes.AddObject(empresas_usuarios_sedes);
            }
        }

        public void UpdateEmpresas_usuarios_sedes(empresas_usuarios_sedes currentempresas_usuarios_sedes)
        {
            this.ObjectContext.empresas_usuarios_sedes.AttachAsModified(currentempresas_usuarios_sedes, this.ChangeSet.GetOriginal(currentempresas_usuarios_sedes));
        }

        public void DeleteEmpresas_usuarios_sedes(empresas_usuarios_sedes empresas_usuarios_sedes)
        {
            if ((empresas_usuarios_sedes.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(empresas_usuarios_sedes, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.empresas_usuarios_sedes.Attach(empresas_usuarios_sedes);
                this.ObjectContext.empresas_usuarios_sedes.DeleteObject(empresas_usuarios_sedes);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'gestiones_incindecias' query.
        public IQueryable<gestiones_incindecias> GetGestiones_incindecias()
        {
            return this.ObjectContext.gestiones_incindecias;
        }

        public void InsertGestiones_incindecias(gestiones_incindecias gestiones_incindecias)
        {
            if ((gestiones_incindecias.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(gestiones_incindecias, EntityState.Added);
            }
            else
            {
                this.ObjectContext.gestiones_incindecias.AddObject(gestiones_incindecias);
            }
        }

        public void UpdateGestiones_incindecias(gestiones_incindecias currentgestiones_incindecias)
        {
            this.ObjectContext.gestiones_incindecias.AttachAsModified(currentgestiones_incindecias, this.ChangeSet.GetOriginal(currentgestiones_incindecias));
        }

        public void DeleteGestiones_incindecias(gestiones_incindecias gestiones_incindecias)
        {
            if ((gestiones_incindecias.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(gestiones_incindecias, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.gestiones_incindecias.Attach(gestiones_incindecias);
                this.ObjectContext.gestiones_incindecias.DeleteObject(gestiones_incindecias);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'incidencias' query.
        public IQueryable<incidencias> GetIncidencias()
        {
            return this.ObjectContext.incidencias;
        }

        public void InsertIncidencias(incidencias incidencias)
        {
            if ((incidencias.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(incidencias, EntityState.Added);
            }
            else
            {
                this.ObjectContext.incidencias.AddObject(incidencias);
            }
        }

        public void UpdateIncidencias(incidencias currentincidencias)
        {
            this.ObjectContext.incidencias.AttachAsModified(currentincidencias, this.ChangeSet.GetOriginal(currentincidencias));
        }

        public void DeleteIncidencias(incidencias incidencias)
        {
            if ((incidencias.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(incidencias, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.incidencias.Attach(incidencias);
                this.ObjectContext.incidencias.DeleteObject(incidencias);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'periodos' query.
        public IQueryable<periodos> GetPeriodos()
        {
            return this.ObjectContext.periodos;
        }

        public void InsertPeriodos(periodos periodos)
        {
            if ((periodos.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(periodos, EntityState.Added);
            }
            else
            {
                this.ObjectContext.periodos.AddObject(periodos);
            }
        }

        public void UpdatePeriodos(periodos currentperiodos)
        {
            this.ObjectContext.periodos.AttachAsModified(currentperiodos, this.ChangeSet.GetOriginal(currentperiodos));
        }

        public void DeletePeriodos(periodos periodos)
        {
            if ((periodos.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(periodos, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.periodos.Attach(periodos);
                this.ObjectContext.periodos.DeleteObject(periodos);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'periodos_evaluaciones_gestiones' query.
        public IQueryable<periodos_evaluaciones_gestiones> GetPeriodos_evaluaciones_gestiones()
        {
            return this.ObjectContext.periodos_evaluaciones_gestiones;
        }

        public void InsertPeriodos_evaluaciones_gestiones(periodos_evaluaciones_gestiones periodos_evaluaciones_gestiones)
        {
            if ((periodos_evaluaciones_gestiones.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(periodos_evaluaciones_gestiones, EntityState.Added);
            }
            else
            {
                this.ObjectContext.periodos_evaluaciones_gestiones.AddObject(periodos_evaluaciones_gestiones);
            }
        }

        public void UpdatePeriodos_evaluaciones_gestiones(periodos_evaluaciones_gestiones currentperiodos_evaluaciones_gestiones)
        {
            this.ObjectContext.periodos_evaluaciones_gestiones.AttachAsModified(currentperiodos_evaluaciones_gestiones, this.ChangeSet.GetOriginal(currentperiodos_evaluaciones_gestiones));
        }

        public void DeletePeriodos_evaluaciones_gestiones(periodos_evaluaciones_gestiones periodos_evaluaciones_gestiones)
        {
            if ((periodos_evaluaciones_gestiones.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(periodos_evaluaciones_gestiones, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.periodos_evaluaciones_gestiones.Attach(periodos_evaluaciones_gestiones);
                this.ObjectContext.periodos_evaluaciones_gestiones.DeleteObject(periodos_evaluaciones_gestiones);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'procesos_gestiones_incidencias' query.
        public IQueryable<procesos_gestiones_incidencias> GetProcesos_gestiones_incidencias()
        {
            return this.ObjectContext.procesos_gestiones_incidencias;
        }

        public void InsertProcesos_gestiones_incidencias(procesos_gestiones_incidencias procesos_gestiones_incidencias)
        {
            if ((procesos_gestiones_incidencias.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(procesos_gestiones_incidencias, EntityState.Added);
            }
            else
            {
                this.ObjectContext.procesos_gestiones_incidencias.AddObject(procesos_gestiones_incidencias);
            }
        }

        public void UpdateProcesos_gestiones_incidencias(procesos_gestiones_incidencias currentprocesos_gestiones_incidencias)
        {
            this.ObjectContext.procesos_gestiones_incidencias.AttachAsModified(currentprocesos_gestiones_incidencias, this.ChangeSet.GetOriginal(currentprocesos_gestiones_incidencias));
        }

        public void DeleteProcesos_gestiones_incidencias(procesos_gestiones_incidencias procesos_gestiones_incidencias)
        {
            if ((procesos_gestiones_incidencias.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(procesos_gestiones_incidencias, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.procesos_gestiones_incidencias.Attach(procesos_gestiones_incidencias);
                this.ObjectContext.procesos_gestiones_incidencias.DeleteObject(procesos_gestiones_incidencias);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'procesos_gestiones_incidencias_saltos' query.
        public IQueryable<procesos_gestiones_incidencias_saltos> GetProcesos_gestiones_incidencias_saltos()
        {
            return this.ObjectContext.procesos_gestiones_incidencias_saltos;
        }

        public void InsertProcesos_gestiones_incidencias_saltos(procesos_gestiones_incidencias_saltos procesos_gestiones_incidencias_saltos)
        {
            if ((procesos_gestiones_incidencias_saltos.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(procesos_gestiones_incidencias_saltos, EntityState.Added);
            }
            else
            {
                this.ObjectContext.procesos_gestiones_incidencias_saltos.AddObject(procesos_gestiones_incidencias_saltos);
            }
        }

        public void UpdateProcesos_gestiones_incidencias_saltos(procesos_gestiones_incidencias_saltos currentprocesos_gestiones_incidencias_saltos)
        {
            this.ObjectContext.procesos_gestiones_incidencias_saltos.AttachAsModified(currentprocesos_gestiones_incidencias_saltos, this.ChangeSet.GetOriginal(currentprocesos_gestiones_incidencias_saltos));
        }

        public void DeleteProcesos_gestiones_incidencias_saltos(procesos_gestiones_incidencias_saltos procesos_gestiones_incidencias_saltos)
        {
            if ((procesos_gestiones_incidencias_saltos.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(procesos_gestiones_incidencias_saltos, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.procesos_gestiones_incidencias_saltos.Attach(procesos_gestiones_incidencias_saltos);
                this.ObjectContext.procesos_gestiones_incidencias_saltos.DeleteObject(procesos_gestiones_incidencias_saltos);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'procesos_incidencias' query.
        public IQueryable<procesos_incidencias> GetProcesos_incidencias()
        {
            return this.ObjectContext.procesos_incidencias;
        }

        public void InsertProcesos_incidencias(procesos_incidencias procesos_incidencias)
        {
            if ((procesos_incidencias.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(procesos_incidencias, EntityState.Added);
            }
            else
            {
                this.ObjectContext.procesos_incidencias.AddObject(procesos_incidencias);
            }
        }

        public void UpdateProcesos_incidencias(procesos_incidencias currentprocesos_incidencias)
        {
            this.ObjectContext.procesos_incidencias.AttachAsModified(currentprocesos_incidencias, this.ChangeSet.GetOriginal(currentprocesos_incidencias));
        }

        public void DeleteProcesos_incidencias(procesos_incidencias procesos_incidencias)
        {
            if ((procesos_incidencias.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(procesos_incidencias, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.procesos_incidencias.Attach(procesos_incidencias);
                this.ObjectContext.procesos_incidencias.DeleteObject(procesos_incidencias);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'productos' query.
        public IQueryable<productos> GetProductos()
        {
            return this.ObjectContext.productos;
        }

        public void InsertProductos(productos productos)
        {
            if ((productos.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(productos, EntityState.Added);
            }
            else
            {
                this.ObjectContext.productos.AddObject(productos);
            }
        }

        public void UpdateProductos(productos currentproductos)
        {
            this.ObjectContext.productos.AttachAsModified(currentproductos, this.ChangeSet.GetOriginal(currentproductos));
        }

        public void DeleteProductos(productos productos)
        {
            if ((productos.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(productos, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.productos.Attach(productos);
                this.ObjectContext.productos.DeleteObject(productos);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'ramos' query.
        public IQueryable<ramos> GetRamos()
        {
            return this.ObjectContext.ramos;
        }

        public void InsertRamos(ramos ramos)
        {
            if ((ramos.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(ramos, EntityState.Added);
            }
            else
            {
                this.ObjectContext.ramos.AddObject(ramos);
            }
        }

        public void UpdateRamos(ramos currentramos)
        {
            this.ObjectContext.ramos.AttachAsModified(currentramos, this.ChangeSet.GetOriginal(currentramos));
        }

        public void DeleteRamos(ramos ramos)
        {
            if ((ramos.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(ramos, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.ramos.Attach(ramos);
                this.ObjectContext.ramos.DeleteObject(ramos);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'sedes' query.
        public IQueryable<sedes> GetSedes()
        {
            return this.ObjectContext.sedes;
        }

        public void InsertSedes(sedes sedes)
        {
            if ((sedes.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(sedes, EntityState.Added);
            }
            else
            {
                this.ObjectContext.sedes.AddObject(sedes);
            }
        }

        public void UpdateSedes(sedes currentsedes)
        {
            this.ObjectContext.sedes.AttachAsModified(currentsedes, this.ChangeSet.GetOriginal(currentsedes));
        }

        public void DeleteSedes(sedes sedes)
        {
            if ((sedes.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(sedes, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.sedes.Attach(sedes);
                this.ObjectContext.sedes.DeleteObject(sedes);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'semaforo_periodos_evaluaciones' query.
        public IQueryable<semaforo_periodos_evaluaciones> GetSemaforo_periodos_evaluaciones()
        {
            return this.ObjectContext.semaforo_periodos_evaluaciones;
        }

        public void InsertSemaforo_periodos_evaluaciones(semaforo_periodos_evaluaciones semaforo_periodos_evaluaciones)
        {
            if ((semaforo_periodos_evaluaciones.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(semaforo_periodos_evaluaciones, EntityState.Added);
            }
            else
            {
                this.ObjectContext.semaforo_periodos_evaluaciones.AddObject(semaforo_periodos_evaluaciones);
            }
        }

        public void UpdateSemaforo_periodos_evaluaciones(semaforo_periodos_evaluaciones currentsemaforo_periodos_evaluaciones)
        {
            this.ObjectContext.semaforo_periodos_evaluaciones.AttachAsModified(currentsemaforo_periodos_evaluaciones, this.ChangeSet.GetOriginal(currentsemaforo_periodos_evaluaciones));
        }

        public void DeleteSemaforo_periodos_evaluaciones(semaforo_periodos_evaluaciones semaforo_periodos_evaluaciones)
        {
            if ((semaforo_periodos_evaluaciones.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(semaforo_periodos_evaluaciones, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.semaforo_periodos_evaluaciones.Attach(semaforo_periodos_evaluaciones);
                this.ObjectContext.semaforo_periodos_evaluaciones.DeleteObject(semaforo_periodos_evaluaciones);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'semaforos' query.
        public IQueryable<semaforos> GetSemaforos()
        {
            return this.ObjectContext.semaforos;
        }

        public void InsertSemaforos(semaforos semaforos)
        {
            if ((semaforos.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(semaforos, EntityState.Added);
            }
            else
            {
                this.ObjectContext.semaforos.AddObject(semaforos);
            }
        }

        public void UpdateSemaforos(semaforos currentsemaforos)
        {
            this.ObjectContext.semaforos.AttachAsModified(currentsemaforos, this.ChangeSet.GetOriginal(currentsemaforos));
        }

        public void DeleteSemaforos(semaforos semaforos)
        {
            if ((semaforos.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(semaforos, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.semaforos.Attach(semaforos);
                this.ObjectContext.semaforos.DeleteObject(semaforos);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'tipos_incidencias' query.
        public IQueryable<tipos_incidencias> GetTipos_incidencias()
        {
            return this.ObjectContext.tipos_incidencias;
        }

        public void InsertTipos_incidencias(tipos_incidencias tipos_incidencias)
        {
            if ((tipos_incidencias.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(tipos_incidencias, EntityState.Added);
            }
            else
            {
                this.ObjectContext.tipos_incidencias.AddObject(tipos_incidencias);
            }
        }

        public void UpdateTipos_incidencias(tipos_incidencias currenttipos_incidencias)
        {
            this.ObjectContext.tipos_incidencias.AttachAsModified(currenttipos_incidencias, this.ChangeSet.GetOriginal(currenttipos_incidencias));
        }

        public void DeleteTipos_incidencias(tipos_incidencias tipos_incidencias)
        {
            if ((tipos_incidencias.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(tipos_incidencias, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.tipos_incidencias.Attach(tipos_incidencias);
                this.ObjectContext.tipos_incidencias.DeleteObject(tipos_incidencias);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'usuarios' query.
        public IQueryable<usuarios> GetUsuarios()
        {
            return this.ObjectContext.usuarios;
        }

        public void InsertUsuarios(usuarios usuarios)
        {
            if ((usuarios.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(usuarios, EntityState.Added);
            }
            else
            {
                this.ObjectContext.usuarios.AddObject(usuarios);
            }
        }

        public void UpdateUsuarios(usuarios currentusuarios)
        {
            this.ObjectContext.usuarios.AttachAsModified(currentusuarios, this.ChangeSet.GetOriginal(currentusuarios));
        }

        public void DeleteUsuarios(usuarios usuarios)
        {
            if ((usuarios.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(usuarios, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.usuarios.Attach(usuarios);
                this.ObjectContext.usuarios.DeleteObject(usuarios);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'usuarios_productos' query.
        public IQueryable<usuarios_productos> GetUsuarios_productos()
        {
            return this.ObjectContext.usuarios_productos;
        }

        public void InsertUsuarios_productos(usuarios_productos usuarios_productos)
        {
            if ((usuarios_productos.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(usuarios_productos, EntityState.Added);
            }
            else
            {
                this.ObjectContext.usuarios_productos.AddObject(usuarios_productos);
            }
        }

        public void UpdateUsuarios_productos(usuarios_productos currentusuarios_productos)
        {
            this.ObjectContext.usuarios_productos.AttachAsModified(currentusuarios_productos, this.ChangeSet.GetOriginal(currentusuarios_productos));
        }

        public void DeleteUsuarios_productos(usuarios_productos usuarios_productos)
        {
            if ((usuarios_productos.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(usuarios_productos, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.usuarios_productos.Attach(usuarios_productos);
                this.ObjectContext.usuarios_productos.DeleteObject(usuarios_productos);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'usuarios_productos_ramos' query.
        public IQueryable<usuarios_productos_ramos> GetUsuarios_productos_ramos()
        {
            return this.ObjectContext.usuarios_productos_ramos;
        }

        public void InsertUsuarios_productos_ramos(usuarios_productos_ramos usuarios_productos_ramos)
        {
            if ((usuarios_productos_ramos.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(usuarios_productos_ramos, EntityState.Added);
            }
            else
            {
                this.ObjectContext.usuarios_productos_ramos.AddObject(usuarios_productos_ramos);
            }
        }

        public void UpdateUsuarios_productos_ramos(usuarios_productos_ramos currentusuarios_productos_ramos)
        {
            this.ObjectContext.usuarios_productos_ramos.AttachAsModified(currentusuarios_productos_ramos, this.ChangeSet.GetOriginal(currentusuarios_productos_ramos));
        }

        public void DeleteUsuarios_productos_ramos(usuarios_productos_ramos usuarios_productos_ramos)
        {
            if ((usuarios_productos_ramos.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(usuarios_productos_ramos, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.usuarios_productos_ramos.Attach(usuarios_productos_ramos);
                this.ObjectContext.usuarios_productos_ramos.DeleteObject(usuarios_productos_ramos);
            }
        }
    }
}


