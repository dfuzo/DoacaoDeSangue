CREATE VIEW vw_Doador_Historico AS
WITH UltimaDoacao AS (
    SELECT 
        Id_Doador,
        MAX(Data_Doacao) AS Ultima_Doacao
    FROM Doacao
    GROUP BY Id_Doador
)
SELECT 
    d.Cpf,
    d.Nome,
    ts.Tipo + ts.Fator_Rh AS Tipo_Sanguineo,
    COUNT(doacao.Id_Doacao) AS Total_Doacoes, 
    COALESCE(SUM(doacao.Volume_Coletado), 0) AS Volume_Total_Doado,
    ud.Ultima_Doacao,
    MAX(h.Nome) AS Nome_Hemocentro, 
    CASE 
        WHEN ud.Ultima_Doacao IS NULL THEN 'Inativo'
        WHEN d.Sexo = 'Masculino' AND ud.Ultima_Doacao >= DATEADD(DAY, -60, GETDATE()) THEN 'Ativo'
        WHEN d.Sexo = 'Feminino' AND ud.Ultima_Doacao >= DATEADD(DAY, -90, GETDATE()) THEN 'Ativo'
        ELSE 'Inativo'
    END AS Status_Doador
FROM Doador d
LEFT JOIN UltimaDoacao ud ON d.Cpf = ud.Id_Doador
LEFT JOIN Doacao doacao ON d.Cpf = doacao.Id_Doador -- Agora inclui todas as doações
LEFT JOIN Tipo_Sanguineo ts ON d.Id_Tipo_Sanguineo = ts.Id_Tipo_Sanguineo
LEFT JOIN Hemocentro h ON doacao.Local_Doacao = h.Nome
GROUP BY d.Cpf, d.Nome, ts.Tipo, ts.Fator_Rh, ud.Ultima_Doacao, d.Sexo;
