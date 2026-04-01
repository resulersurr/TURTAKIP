/* 
   TurTakip v9.0 Veritabanı Güncelleme Scripti 
   Bu scripti SQL Server Management Studio (SSMS) üzerinde TurTakip veritabanında çalıştırın.
*/

IF NOT EXISTS (
    SELECT * FROM sys.columns 
    WHERE object_id = OBJECT_ID(N'[dbo].[TourDates]') 
    AND name = 'PhotoUrl'
)
BEGIN
    ALTER TABLE [dbo].[TourDates] ADD [PhotoUrl] NVARCHAR(MAX) NULL;
    PRINT 'PhotoUrl sütunu başarıyla eklendi.';
END
ELSE
BEGIN
    PRINT 'PhotoUrl sütunu zaten mevcut.';
END
