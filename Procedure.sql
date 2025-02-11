CREATE PROCEDURE sp_ListarFuncionarios
    @HemocentroID VARCHAR(14) = NULL,
    @Cargo VARCHAR(30) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        f.Ponto,
        f.Nome,
        f.Sexo,
        f.Telefone,
        f.Email,
        f.Cargo,
        h.CNPJ AS Hemocentro, 
        h.Nome AS Nome_Hemocentro
    FROM Funcionario f
    LEFT JOIN Hemocentro h ON f.Hemocentro = h.CNPJ
    WHERE 
        (@HemocentroID IS NULL OR f.Hemocentro = @HemocentroID)
        AND (@Cargo IS NULL OR f.Cargo = @Cargo)
    ORDER BY f.Nome;
END;
