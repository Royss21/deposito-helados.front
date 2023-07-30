
namespace DepositoHelados.Domain.Commons;

public struct Constants {

    public const string CURRENT_USER_DEFAULT = "system";
    
    #region Claims
    public const string CLAIM_USERNAME = "userName";
    public const string CLAIM_COMPANY = "company";
    public const string CLAIM_CAMPUS = "campus";
    #endregion

    #region Messages
    public const string SUCCESS_MESSAGE = "Se ha procesado con exitosamente la operacion.";
    public const string VALUE_NULL ="No se ha encontrado ningun dato.";
    public const string QUANTITY_ZERO = "Debe ingresar minimo 1 cantidad por producto.";
    public const string ORDER_PRODUCT_NOT_EXISTS = "El pedido de productos que desea actualizar no existe.";

    public const string NO_ASSIGN_ROLE_EMPLOYEE = "{0} no tiene asignado el rol de empleado.";
    public const string PRODUCT_INACTIVE = "El producto de la fila {0} no esta activo.";
    public const string PRODUCT_NOT_EXISTS = "El producto de la fila {0} no existe.";
    #endregion


    #region Tables Values
    public const string ROLE_EMPLOYEE = "EMPLOYEE";
    public const string ROLE_CUSTOMER = "CUSTOMER";
    #endregion


}