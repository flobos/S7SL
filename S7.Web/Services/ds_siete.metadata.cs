
namespace S7.Web.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Data.Objects.DataClasses;
    using System.Linq;
    using System.ServiceModel.DomainServices.Hosting;
    using System.ServiceModel.DomainServices.Server;


    // The MetadataTypeAttribute identifies anosMetadata as the class
    // that carries additional metadata for the anos class.
    [MetadataTypeAttribute(typeof(anos.anosMetadata))]
    public partial class anos
    {

        // This class allows you to attach custom attributes to properties
        // of the anos class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class anosMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private anosMetadata()
            {
            }

            public int ano_idn { get; set; }

            public string ano_nombre { get; set; }

            public EntityCollection<usuarios_productos> usuarios_productos { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies atencionesMetadata as the class
    // that carries additional metadata for the atenciones class.
    [MetadataTypeAttribute(typeof(atenciones.atencionesMetadata))]
    public partial class atenciones
    {

        // This class allows you to attach custom attributes to properties
        // of the atenciones class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class atencionesMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private atencionesMetadata()
            {
            }

            public bool ate_cerrada { get; set; }

            public DateTime ate_fecha_ingreso { get; set; }

            public int ate_idn { get; set; }

            public EntityCollection<atenciones_incidencias> atenciones_incidencias { get; set; }

            public int emp_usu_sed_idn { get; set; }

            public empresas_usuarios_sedes empresas_usuarios_sedes { get; set; }

            public int usu_idn { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies atenciones_incidenciasMetadata as the class
    // that carries additional metadata for the atenciones_incidencias class.
    [MetadataTypeAttribute(typeof(atenciones_incidencias.atenciones_incidenciasMetadata))]
    public partial class atenciones_incidencias
    {

        // This class allows you to attach custom attributes to properties
        // of the atenciones_incidencias class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class atenciones_incidenciasMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private atenciones_incidenciasMetadata()
            {
            }

            public int ate_idn { get; set; }

            public DateTime ate_inc_fecha_ingreso { get; set; }

            public Nullable<DateTime> ate_inc_fecha_resuelta { get; set; }

            public int ate_inc_idn { get; set; }

            public string ate_inc_observacion { get; set; }

            public string ate_inc_resolucion { get; set; }

            public bool ate_inc_resuelta { get; set; }

            public atenciones atenciones { get; set; }

            public EntityCollection<atenciones_procesos_incidencias> atenciones_procesos_incidencias { get; set; }

            public int inc_idn { get; set; }

            public incidencias incidencias { get; set; }

            public int usu_pro_idn { get; set; }

            public usuarios_productos usuarios_productos { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies atenciones_procesos_incidenciasMetadata as the class
    // that carries additional metadata for the atenciones_procesos_incidencias class.
    [MetadataTypeAttribute(typeof(atenciones_procesos_incidencias.atenciones_procesos_incidenciasMetadata))]
    public partial class atenciones_procesos_incidencias
    {

        // This class allows you to attach custom attributes to properties
        // of the atenciones_procesos_incidencias class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class atenciones_procesos_incidenciasMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private atenciones_procesos_incidenciasMetadata()
            {
            }

            public int ate_inc_idn { get; set; }

            public DateTime ate_pro_inc_fecha_ingreso { get; set; }

            public int ate_pro_inc_idn { get; set; }

            public string ate_pro_inc_observacion { get; set; }

            public atenciones_incidencias atenciones_incidencias { get; set; }

            public int emp_usu_sed_idn { get; set; }

            public empresas_usuarios_sedes empresas_usuarios_sedes { get; set; }

            public int pro_ges_inc_idn { get; set; }

            public procesos_gestiones_incidencias procesos_gestiones_incidencias { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies cargosMetadata as the class
    // that carries additional metadata for the cargos class.
    [MetadataTypeAttribute(typeof(cargos.cargosMetadata))]
    public partial class cargos
    {

        // This class allows you to attach custom attributes to properties
        // of the cargos class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class cargosMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private cargosMetadata()
            {
            }

            public int car_idn { get; set; }

            public string car_nombre { get; set; }

            public EntityCollection<empresas_usuarios_sedes> empresas_usuarios_sedes { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies empresasMetadata as the class
    // that carries additional metadata for the empresas class.
    [MetadataTypeAttribute(typeof(empresas.empresasMetadata))]
    public partial class empresas
    {

        // This class allows you to attach custom attributes to properties
        // of the empresas class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class empresasMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private empresasMetadata()
            {
            }

            public string emp_id_nacional { get; set; }

            public int emp_idn { get; set; }

            public string emp_nombre { get; set; }

            public EntityCollection<empresas_usuarios_sedes> empresas_usuarios_sedes { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies empresas_usuarios_sedesMetadata as the class
    // that carries additional metadata for the empresas_usuarios_sedes class.
    [MetadataTypeAttribute(typeof(empresas_usuarios_sedes.empresas_usuarios_sedesMetadata))]
    public partial class empresas_usuarios_sedes
    {

        // This class allows you to attach custom attributes to properties
        // of the empresas_usuarios_sedes class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class empresas_usuarios_sedesMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private empresas_usuarios_sedesMetadata()
            {
            }

            public EntityCollection<atenciones> atenciones { get; set; }

            public EntityCollection<atenciones_procesos_incidencias> atenciones_procesos_incidencias { get; set; }

            public int car_idn { get; set; }

            public cargos cargos { get; set; }

            public int emp_idn { get; set; }

            public DateTime emp_usu_sed_fecha_ingreso { get; set; }

            public int emp_usu_sed_idn { get; set; }

            public empresas empresas { get; set; }

            public EntityCollection<productos> productos { get; set; }

            public int sed_idn { get; set; }

            public sedes sedes { get; set; }

            public int usu_idn { get; set; }

            public usuarios usuarios { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies gestiones_incindeciasMetadata as the class
    // that carries additional metadata for the gestiones_incindecias class.
    [MetadataTypeAttribute(typeof(gestiones_incindecias.gestiones_incindeciasMetadata))]
    public partial class gestiones_incindecias
    {

        // This class allows you to attach custom attributes to properties
        // of the gestiones_incindecias class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class gestiones_incindeciasMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private gestiones_incindeciasMetadata()
            {
            }

            public int ges_inc_idn { get; set; }

            public string ges_inc_nombre { get; set; }

            public EntityCollection<procesos_gestiones_incidencias> procesos_gestiones_incidencias { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies incidenciasMetadata as the class
    // that carries additional metadata for the incidencias class.
    [MetadataTypeAttribute(typeof(incidencias.incidenciasMetadata))]
    public partial class incidencias
    {

        // This class allows you to attach custom attributes to properties
        // of the incidencias class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class incidenciasMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private incidenciasMetadata()
            {
            }

            public EntityCollection<atenciones_incidencias> atenciones_incidencias { get; set; }

            public int inc_idn { get; set; }

            public string inc_nombre { get; set; }

            public Nullable<int> tip_inc_idn { get; set; }

            public tipos_incidencias tipos_incidencias { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies periodosMetadata as the class
    // that carries additional metadata for the periodos class.
    [MetadataTypeAttribute(typeof(periodos.periodosMetadata))]
    public partial class periodos
    {

        // This class allows you to attach custom attributes to properties
        // of the periodos class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class periodosMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private periodosMetadata()
            {
            }

            public int per_idn { get; set; }

            public string per_nombre { get; set; }

            public EntityCollection<usuarios_productos> usuarios_productos { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies periodos_evaluaciones_gestionesMetadata as the class
    // that carries additional metadata for the periodos_evaluaciones_gestiones class.
    [MetadataTypeAttribute(typeof(periodos_evaluaciones_gestiones.periodos_evaluaciones_gestionesMetadata))]
    public partial class periodos_evaluaciones_gestiones
    {

        // This class allows you to attach custom attributes to properties
        // of the periodos_evaluaciones_gestiones class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class periodos_evaluaciones_gestionesMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private periodos_evaluaciones_gestionesMetadata()
            {
            }

            public bool per_eva_ges_activo { get; set; }

            public DateTime per_eva_ges_fecha_inicio { get; set; }

            public int per_eva_ges_idn { get; set; }

            public EntityCollection<semaforo_periodos_evaluaciones> semaforo_periodos_evaluaciones { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies procesos_gestiones_incidenciasMetadata as the class
    // that carries additional metadata for the procesos_gestiones_incidencias class.
    [MetadataTypeAttribute(typeof(procesos_gestiones_incidencias.procesos_gestiones_incidenciasMetadata))]
    public partial class procesos_gestiones_incidencias
    {

        // This class allows you to attach custom attributes to properties
        // of the procesos_gestiones_incidencias class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class procesos_gestiones_incidenciasMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private procesos_gestiones_incidenciasMetadata()
            {
            }

            public EntityCollection<atenciones_procesos_incidencias> atenciones_procesos_incidencias { get; set; }

            public int ges_inc_idn { get; set; }

            public gestiones_incindecias gestiones_incindecias { get; set; }

            public int pro_ges_inc_idn { get; set; }

            public int pro_inc_idn { get; set; }

            public EntityCollection<procesos_gestiones_incidencias_saltos> procesos_gestiones_incidencias_saltos { get; set; }

            public EntityCollection<procesos_gestiones_incidencias_saltos> procesos_gestiones_incidencias_saltos1 { get; set; }

            public procesos_incidencias procesos_incidencias { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies procesos_gestiones_incidencias_saltosMetadata as the class
    // that carries additional metadata for the procesos_gestiones_incidencias_saltos class.
    [MetadataTypeAttribute(typeof(procesos_gestiones_incidencias_saltos.procesos_gestiones_incidencias_saltosMetadata))]
    public partial class procesos_gestiones_incidencias_saltos
    {

        // This class allows you to attach custom attributes to properties
        // of the procesos_gestiones_incidencias_saltos class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class procesos_gestiones_incidencias_saltosMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private procesos_gestiones_incidencias_saltosMetadata()
            {
            }

            public int pro_ges_inc_idn { get; set; }

            public int pro_ges_inc_idn_salta { get; set; }

            public int pro_ges_inc_sal { get; set; }

            public procesos_gestiones_incidencias procesos_gestiones_incidencias { get; set; }

            public procesos_gestiones_incidencias procesos_gestiones_incidencias1 { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies procesos_incidenciasMetadata as the class
    // that carries additional metadata for the procesos_incidencias class.
    [MetadataTypeAttribute(typeof(procesos_incidencias.procesos_incidenciasMetadata))]
    public partial class procesos_incidencias
    {

        // This class allows you to attach custom attributes to properties
        // of the procesos_incidencias class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class procesos_incidenciasMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private procesos_incidenciasMetadata()
            {
            }

            public int pro_inc_idn { get; set; }

            public string pro_inc_nombre { get; set; }

            public EntityCollection<procesos_gestiones_incidencias> procesos_gestiones_incidencias { get; set; }

            public EntityCollection<semaforo_periodos_evaluaciones> semaforo_periodos_evaluaciones { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies productosMetadata as the class
    // that carries additional metadata for the productos class.
    [MetadataTypeAttribute(typeof(productos.productosMetadata))]
    public partial class productos
    {

        // This class allows you to attach custom attributes to properties
        // of the productos class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class productosMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private productosMetadata()
            {
            }

            public int emp_usu_sed_idn { get; set; }

            public empresas_usuarios_sedes empresas_usuarios_sedes { get; set; }

            public string pro_codigo_umas { get; set; }

            public int pro_idn { get; set; }

            public string pro_nombre { get; set; }

            public EntityCollection<usuarios_productos> usuarios_productos { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies ramosMetadata as the class
    // that carries additional metadata for the ramos class.
    [MetadataTypeAttribute(typeof(ramos.ramosMetadata))]
    public partial class ramos
    {

        // This class allows you to attach custom attributes to properties
        // of the ramos class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class ramosMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private ramosMetadata()
            {
            }

            public string ram_codigo_umas { get; set; }

            public int ram_idn { get; set; }

            public string ram_nombre { get; set; }

            public EntityCollection<usuarios_productos_ramos> usuarios_productos_ramos { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies sedesMetadata as the class
    // that carries additional metadata for the sedes class.
    [MetadataTypeAttribute(typeof(sedes.sedesMetadata))]
    public partial class sedes
    {

        // This class allows you to attach custom attributes to properties
        // of the sedes class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class sedesMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private sedesMetadata()
            {
            }

            public EntityCollection<empresas_usuarios_sedes> empresas_usuarios_sedes { get; set; }

            public int sed_idn { get; set; }

            public string sed_nombre { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies semaforo_periodos_evaluacionesMetadata as the class
    // that carries additional metadata for the semaforo_periodos_evaluaciones class.
    [MetadataTypeAttribute(typeof(semaforo_periodos_evaluaciones.semaforo_periodos_evaluacionesMetadata))]
    public partial class semaforo_periodos_evaluaciones
    {

        // This class allows you to attach custom attributes to properties
        // of the semaforo_periodos_evaluaciones class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class semaforo_periodos_evaluacionesMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private semaforo_periodos_evaluacionesMetadata()
            {
            }

            public int per_eva_ges_idn { get; set; }

            public periodos_evaluaciones_gestiones periodos_evaluaciones_gestiones { get; set; }

            public int pro_inc_idn { get; set; }

            public procesos_incidencias procesos_incidencias { get; set; }

            public int sem_idn { get; set; }

            public int sem_per_dias_desde { get; set; }

            public int sem_per_dias_hasta { get; set; }

            public int sem_per_idn { get; set; }

            public semaforos semaforos { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies semaforosMetadata as the class
    // that carries additional metadata for the semaforos class.
    [MetadataTypeAttribute(typeof(semaforos.semaforosMetadata))]
    public partial class semaforos
    {

        // This class allows you to attach custom attributes to properties
        // of the semaforos class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class semaforosMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private semaforosMetadata()
            {
            }

            public string sem_codigo_color { get; set; }

            public string sem_color { get; set; }

            public int sem_idn { get; set; }

            public EntityCollection<semaforo_periodos_evaluaciones> semaforo_periodos_evaluaciones { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies tipos_incidenciasMetadata as the class
    // that carries additional metadata for the tipos_incidencias class.
    [MetadataTypeAttribute(typeof(tipos_incidencias.tipos_incidenciasMetadata))]
    public partial class tipos_incidencias
    {

        // This class allows you to attach custom attributes to properties
        // of the tipos_incidencias class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class tipos_incidenciasMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private tipos_incidenciasMetadata()
            {
            }

            public EntityCollection<incidencias> incidencias { get; set; }

            public int tip_inc_idn { get; set; }

            public string tip_inc_nombre { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies usuariosMetadata as the class
    // that carries additional metadata for the usuarios class.
    [MetadataTypeAttribute(typeof(usuarios.usuariosMetadata))]
    public partial class usuarios
    {

        // This class allows you to attach custom attributes to properties
        // of the usuarios class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class usuariosMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private usuariosMetadata()
            {
            }

            public EntityCollection<empresas_usuarios_sedes> empresas_usuarios_sedes { get; set; }

            public string usu_apellidos { get; set; }

            public string usu_clave { get; set; }

            public string usu_email { get; set; }

            public string usu_id_nacional { get; set; }

            public int usu_idn { get; set; }

            public string usu_nombres { get; set; }

            public EntityCollection<usuarios_productos> usuarios_productos { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies usuarios_productosMetadata as the class
    // that carries additional metadata for the usuarios_productos class.
    [MetadataTypeAttribute(typeof(usuarios_productos.usuarios_productosMetadata))]
    public partial class usuarios_productos
    {

        // This class allows you to attach custom attributes to properties
        // of the usuarios_productos class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class usuarios_productosMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private usuarios_productosMetadata()
            {
            }

            public int ano_idn { get; set; }

            public anos anos { get; set; }

            public EntityCollection<atenciones_incidencias> atenciones_incidencias { get; set; }

            public int per_idn { get; set; }

            public periodos periodos { get; set; }

            public int pro_idn { get; set; }

            public productos productos { get; set; }

            public int usu_idn { get; set; }

            public bool usu_pro_activo { get; set; }

            public int usu_pro_idn { get; set; }

            public usuarios usuarios { get; set; }

            public EntityCollection<usuarios_productos_ramos> usuarios_productos_ramos { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies usuarios_productos_ramosMetadata as the class
    // that carries additional metadata for the usuarios_productos_ramos class.
    [MetadataTypeAttribute(typeof(usuarios_productos_ramos.usuarios_productos_ramosMetadata))]
    public partial class usuarios_productos_ramos
    {

        // This class allows you to attach custom attributes to properties
        // of the usuarios_productos_ramos class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class usuarios_productos_ramosMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private usuarios_productos_ramosMetadata()
            {
            }

            public int ram_idn { get; set; }

            public ramos ramos { get; set; }

            public int usu_pro_idn { get; set; }

            public int usu_pro_ram_idn { get; set; }

            public usuarios_productos usuarios_productos { get; set; }
        }
    }
}
