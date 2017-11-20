----------------------------------------------------------------------------------------
---TABLAS-------------------------------------------------------------------------------
----------------------------------------------------------------------------------------

CREATE TABLE TasaCambiaria
(
  CodMoneda CHAR(3) PRIMARY KEY,
  Monto DECIMAL(18,2) NOT NULL DEFAULT (0.00)
);

CREATE TABLE IndiceInflacion
(
  InflacionId SERIAL PRIMARY KEY,
  Periodo CHAR(6) UNIQUE NOT NULL,
  Indice DECIMAL(10,2) NOT NULL
);

CREATE TABLE SaludFinanciera
(
  Cedula VARCHAR(11) PRIMARY KEY,
  Indicador BOOLEAN NOT NULL,
  Comentario VARCHAR(255),
  Monto DECIMAL(18,2)
);

CREATE TABLE HistorialCrediticio
(
  Cedula VARCHAR(11) NOT NULL,
  DeudaRNC VARCHAR(11) NOT NULL,
  Concepto VARCHAR(255),
  Fecha TIMESTAMP NOT NULL,
  Monto DECIMAL(18,2) NOT NULL DEFAULT (0.00)
);

CREATE TABLE Log
(
  Id SERIAL NOT NULL,
  Date TIMESTAMP NOT NULL,
  Thread VARCHAR(255) NOT NULL,
  Level VARCHAR(50) NOT NULL,
  Logger VARCHAR(255) NOT NULL,
  Message VARCHAR(400) NOT NULL,
  Exception VARCHAR(2000),
  IP CHAR(15) NOT NULL
);
----------------------------------------------------------------------------------------
-------PROCEDURES-TASA-CAMBIARIA--------------------------------------------------------
----------------------------------------------------------------------------------------
CREATE OR REPLACE FUNCTION AgregarTasaCambiaria(codmoneda CHAR(3), monto DECIMAL(18,2))
  RETURNS VOID AS $$
BEGIN
    INSERT INTO TasaCambiaria (CodMoneda, Monto) VALUES (codmoneda,monto);
END;
$$ LANGUAGE PLPGSQL;

CREATE OR REPLACE FUNCTION ActualizarTasaCambiaria(codmonedaParam CHAR(3),montoParam DECIMAL(18,2))
  RETURNS VOID AS $$
  BEGIN
    UPDATE TasaCambiaria TC
      SET TC.CodMoneda = codmonedaParam,
        TC.Monto = montoParam
    WHERE TC.CodMoneda = codmonedaParam;
  END;
$$ LANGUAGE PLPGSQL;

CREATE OR REPLACE FUNCTION EliminarTasaCambiaria(codmoneda CHAR(3))
  RETURNS VOID AS $$
  BEGIN
    DELETE FROM TasaCambiaria WHERE TasaCambiaria.CodMoneda = codmoneda;
  END;
  $$ LANGUAGE PLPGSQL;

CREATE OR REPLACE FUNCTION ObtenerTasaCambiaria(codmonedaParam CHAR(3) DEFAULT NULL)
  RETURNS TABLE(codmoneda CHAR(3),monto DECIMAL(18,2)) AS $$
  BEGIN
    RETURN QUERY SELECT TasaCambiaria.CodMoneda,
                   TasaCambiaria.Monto
                 FROM TasaCambiaria
                 WHERE TasaCambiaria.CodMoneda = codmonedaParam
                  OR codmonedaParam IS NULL;
  END;
  $$ LANGUAGE PLPGSQL;

----------------------------------------------------------------------------------------
-------PROCEDURES-INDICE-INFLACION------------------------------------------------------
----------------------------------------------------------------------------------------

CREATE OR REPLACE FUNCTION AgregarIndiceInflacion(periodo CHAR(6),indice DECIMAL(18,2))
  RETURNS VOID AS $$
  BEGIN
    INSERT INTO IndiceInflacion (Periodo, Indice) VALUES (periodo,indice);
  END;
  $$ LANGUAGE PLPGSQL;

CREATE OR REPLACE FUNCTION EliminarIndiceInflacion(id INT)
  RETURNS VOID AS $$
  BEGIN
    DELETE FROM IndiceInflacion WHERE InflacionId = id;
  END;
  $$ LANGUAGE PLPGSQL;

CREATE OR REPLACE FUNCTION ObtenerIndiceInflacion(periodoParam CHAR(6) DEFAULT NULL)
  RETURNS TABLE (periodo CHAR(6),indice DECIMAL(10,2)) AS $$
  BEGIN
    RETURN QUERY SELECT IndiceInflacion.Periodo,
                   IndiceInflacion.Indice
                 FROM IndiceInflacion
                 WHERE IndiceInflacion.Periodo = periodoParam
                    OR periodoParam IS NULL;
  END;
$$ LANGUAGE PLPGSQL;

----------------------------------------------------------------------------------------
----PROCEDURES-SALUD-FINANCIERA---------------------------------------------------------
----------------------------------------------------------------------------------------

CREATE OR REPLACE FUNCTION AgregarSaludFinanciera(cedulaParam VARCHAR(11),indicadorParam BOOLEAN,comentarioParam VARCHAR(255),montoParam DECIMAL(18,2))
  RETURNS VOID AS $$
  BEGIN
    INSERT INTO SaludFinanciera
      (Cedula, Indicador, Comentario, Monto)
    VALUES (cedulaParam,indicadorParam,comentarioParam,montoParam);
  END;
$$ LANGUAGE PLPGSQL;

CREATE OR REPLACE FUNCTION ActualizarSaludFinanciera(cedulaParam VARCHAR(11),indicadorParam BOOLEAN,comentarioParam VARCHAR(255),montoParam DECIMAL(18,2))
  RETURNS VOID AS $$
  BEGIN
    UPDATE SaludFinanciera SF
      SET SF.Indicador = indicadorParam,
        SF.Comentario = comentarioParam,
        SF.Monto = montoParam
    WHERE SF.Cedula = cedulaParam;
  END;
$$ LANGUAGE PLPGSQL;

CREATE OR REPLACE FUNCTION ObtenerSaludFinanciera(cedulaParam CHAR(11) DEFAULT NULL)
  RETURNS TABLE(cedula VARCHAR(11),indicador BOOLEAN,comentario VARCHAR(255),monto DECIMAL(18,2)) AS $$
  BEGIN
    RETURN QUERY SELECT SaludFinanciera.Cedula,
                        SaludFinanciera.Indicador,
                        SaludFinanciera.Comentario,
                        SaludFinanciera.Monto
                 FROM SaludFinanciera
                 WHERE SaludFinanciera.Cedula = cedulaParam OR
                        cedulaParam IS NULL;
  END;
  $$ LANGUAGE PLPGSQL;

----------------------------------------------------------------------------------------
------PROCEDURES-HISTORIAL-CREDITICIO---------------------------------------------------
----------------------------------------------------------------------------------------

CREATE OR REPLACE FUNCTION AgregarHistorialCrediticio(cedulaParam VARCHAR(11),
  deudaRNCParam VARCHAR(11),conceptoParam VARCHAR(255),fechaParam TIMESTAMP,montoParam DECIMAL(18,2))
  RETURNS VOID AS $$
  BEGIN
    INSERT INTO HistorialCrediticio
      (Cedula, DeudaRNC, Concepto, Fecha, Monto)
    VALUES
      (cedulaParam,deudaRNCParam,conceptoParam,fechaParam,montoParam);
  END;
$$ LANGUAGE PLPGSQL;

CREATE OR REPLACE FUNCTION ObtenerHistorialCrediticio(cedulaParam VARCHAR(11) DEFAULT NULL )
  RETURNS TABLE(Cedula VARCHAR(11),DeudaRNC VARCHAR(11),Concepto VARCHAR(255),Fecha TIMESTAMP,Monto DECIMAL(18,2)) AS $$
  BEGIN
    RETURN QUERY SELECT HistorialCrediticio.Cedula,
                        HistorialCrediticio.DeudaRNC,
                        HistorialCrediticio.Concepto,
                        HistorialCrediticio.Fecha,
                        HistorialCrediticio.Monto FROM HistorialCrediticio
                  WHERE HistorialCrediticio.Cedula = cedulaParam
                    OR cedulaParam IS NULL;
  END;
  $$ LANGUAGE PLPGSQL;

-- CREATE OR REPLACE FUNCTION ObtenerHistorialCrediticio(ref_cursor REFCURSOR,cedulaParam VARCHAR(11) DEFAULT NULL)
--   RETURNS REFCURSOR AS $$
--   BEGIN
--     OPEN ref_cursor FOR SELECT HistorialCrediticio.Cedula,
--                         HistorialCrediticio.DeudaRNC,
--                         HistorialCrediticio.Concepto,
--                         HistorialCrediticio.Fecha,
--                         HistorialCrediticio.Monto FROM HistorialCrediticio
--                   WHERE HistorialCrediticio.Cedula = cedulaParam
--                     OR cedulaParam IS NULL;
--     RETURN ref_cursor;
--   END;
--   $$ LANGUAGE PLPGSQL;

----------------------------------------------------------------------------------------
----PROCEDURES-LOG----------------------------------------------------------------------
----------------------------------------------------------------------------------------

CREATE OR REPLACE FUNCTION AgregarLog(
    DateParam TIMESTAMP,
    ThreadParam VARCHAR(255),
    LevelParam VARCHAR(50),
    LoggerParam VARCHAR(255),
    MessageParam VARCHAR(400),
    ExceptionParam VARCHAR(2000),
    IPParam VARCHAR(15))
  RETURNS VOID AS $$
  BEGIN
    INSERT INTO Log (Date,Thread,Level,Logger,Message,Exception,IP)
      VALUES
        (DateParam,ThreadParam,LevelParam,LoggerParam,MessageParam,ExceptionParam,IPParam);
  END;
$$ LANGUAGE PLPGSQL;

CREATE OR REPLACE FUNCTION ObtenerLogs(IdParam INT DEFAULT NULL)
  RETURNS TABLE(
    Id INT,
    Date TIMESTAMP,
    Thread VARCHAR(255),
    Level VARCHAR(50),
    Logger VARCHAR(255),
    Message VARCHAR(400),
    Exception VARCHAR(2000),
    IP CHAR(15)) AS $$
    BEGIN
      RETURN QUERY SELECT Log.Id,
                          Log.Date,
                          Log.Thread,
                          Log.Level,
                          Log.Logger,
                          Log.Message,
                          Log.Exception,
                          Log.IP
                   FROM Log WHERE Log.Id = IdParam OR IdParam IS NULL;
    END;
  $$ LANGUAGE PLPGSQL;

