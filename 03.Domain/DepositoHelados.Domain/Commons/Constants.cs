
namespace DepositoHelados.Domain.Commons;

public struct Constants
{

    public const string CURRENT_USER_DEFAULT = "system";

    public struct Claims
    {
        #region Claims
        public const string CLAIM_USERNAME = "userName";
        public const string CLAIM_COMPANY = "company";
        public const string CLAIM_CAMPUS = "campus";
        #endregion
    }


    public struct Messages
    {
        #region Messages
        public const string SUCCESS_MESSAGE = "Se ha procesado con exitosamente la operacion.";
        public const string VALUE_NULL = "No se ha encontrado ningun dato.";
        public const string ITEMS_NOT_FOUND = "No se ha encontrado ningun item.";
        public const string QUANTITY_ZERO = "Debe ingresar minimo 1 cantidad por producto.";
        public const string ORDER_PRODUCT_NOT_EXISTS = "El pedido de productos que desea actualizar no existe.";

        public const string NO_ASSIGN_ROLE_EMPLOYEE = "{0} no tiene asignado el rol de empleado.";
        public const string NO_ASSIGN_ROLE_CUSTOMER = "{0} no tiene asignado el rol de cliente.";
        public const string PRODUCT_INACTIVE = "El producto de la fila {0} no esta activo.";
        public const string PRODUCT_NOT_EXISTS = "El producto de la fila {0} no existe.";
        #endregion

    }

    public struct Codes
    {
        #region Tables Values
        public const string ROLE_EMPLOYEE = "EMPLOYEE";
        public const string ROLE_CUSTOMER = "CUSTOMER";
        public const string MASTER_STATUS = "STATUS";
        public const string MD_STATUS_REGISTERED = "STATUS01";
        public const string MD_STATUS_PAYMENT = "STATUS02";
        public const string MD_STATUS_PENDING_PAYMENT = "STATUS03";
        public const string MD_STATUS_CULMINATED = "STATUS04";
        public const string MD_STATUS_CANCEL = "STATUS05";
        public const string MD_STATUS_ANULADO = "STATUS06";
        #endregion
    }



}