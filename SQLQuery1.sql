
ALTER TABLE [dbo].[Patients]
ADD [Adres] NVARCHAR(MAX) NOT NULL DEFAULT 'Brak danych',
    [Imie] NVARCHAR(MAX) NOT NULL DEFAULT 'Brak danych',
    [Miasto] NVARCHAR(MAX) NOT NULL DEFAULT 'Brak danych';
