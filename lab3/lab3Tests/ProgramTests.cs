using Xunit;
using lab3;

namespace lab3Tests
{
    public class MusicCatalogTests
    {
        [Fact]
        public void AddComposition_ShouldAddToCatalog()
        {
            // Arrange
            MusicCatalog catalog = new MusicCatalog();
            MusicCatalog.MusicComposition composition = new MusicCatalog.MusicComposition("Artist1", "Title1");

            // Act
            catalog.AddComposition(composition);

            // Assert
            Assert.Contains(composition, catalog.GetCatalog());
        }

        [Fact]
        public void DeleteComposition_ShouldRemoveFromCatalog()
        {
            // Arrange
            MusicCatalog catalog = new MusicCatalog();
            MusicCatalog.MusicComposition composition = new MusicCatalog.MusicComposition("Artist1", "Title1");
            catalog.AddComposition(composition);

            // Act
            catalog.DeleteComposition("Artist1", "Title1");

            // Assert
            Assert.DoesNotContain(composition, catalog.GetCatalog());
        }

        [Fact]
        public void SearchComposition_ShouldReturnMatchingResults()
        {
            // Arrange
            MusicCatalog catalog = new MusicCatalog();
            MusicCatalog.MusicComposition composition1 = new MusicCatalog.MusicComposition("Artist1", "Title1");
            MusicCatalog.MusicComposition composition2 = new MusicCatalog.MusicComposition("Artist2", "Title2");
            catalog.AddComposition(composition1);
            catalog.AddComposition(composition2);

            // Act
            var results = catalog.SearchComposition("Artist");

            // Assert
            Assert.Contains(composition1, results);
            Assert.Contains(composition2, results);
        }

        [Fact]
        public void ListAllCompositions_ShouldReturnAllCompositions()
        {
            // Arrange
            MusicCatalog catalog = new MusicCatalog();
            MusicCatalog.MusicComposition composition1 = new MusicCatalog.MusicComposition("Artist1", "Title1");
            MusicCatalog.MusicComposition composition2 = new MusicCatalog.MusicComposition("Artist2", "Title2");
            catalog.AddComposition(composition1);
            catalog.AddComposition(composition2);

            // Act
            var allCompositions = catalog.ListAllCompositions();

            // Assert
            Assert.Contains(composition1, allCompositions);
            Assert.Contains(composition2, allCompositions);
        }

        [Fact]
        public void SaveAndLoadFromJSON_ShouldPreserveData()
        {
            // Arrange
            MusicCatalog catalog = new MusicCatalog();
            MusicCatalog.MusicComposition composition1 = new MusicCatalog.MusicComposition("Artist1", "Title1");
            MusicCatalog.MusicComposition composition2 = new MusicCatalog.MusicComposition("Artist2", "Title2");
            catalog.AddComposition(composition1);
            catalog.AddComposition(composition2);

            // Act
            catalog.SaveToJSON();
            catalog.LoadFromJSON();
            var loadedCompositions = catalog.GetCatalog();

            // Assert
            Assert.Contains(composition1, loadedCompositions);
            Assert.Contains(composition2, loadedCompositions);
        }

        [Fact]
        public void SaveAndLoadFromXML_ShouldPreserveData()
        {
            // Arrange
            MusicCatalog catalog = new MusicCatalog();
            MusicCatalog.MusicComposition composition1 = new MusicCatalog.MusicComposition("Artist1", "Title1");
            MusicCatalog.MusicComposition composition2 = new MusicCatalog.MusicComposition("Artist2", "Title2");
            catalog.AddComposition(composition1);
            catalog.AddComposition(composition2);

            // Act
            catalog.SaveToXML();
            catalog.LoadFromXML();
            var loadedCompositions = catalog.GetCatalog();

            // Assert
            Assert.Contains(composition1, loadedCompositions);
            Assert.Contains(composition2, loadedCompositions);
        }

        [Fact]
        public void SaveAndLoadFromSQLite_ShouldPreserveData()
        {
            // Arrange
            MusicCatalog catalog = new MusicCatalog();
            MusicCatalog.MusicComposition composition1 = new MusicCatalog.MusicComposition("Artist1", "Title1");
            MusicCatalog.MusicComposition composition2 = new MusicCatalog.MusicComposition("Artist2", "Title2");
            catalog.AddComposition(composition1);
            catalog.AddComposition(composition2);

            // Act
            catalog.SaveToSQLite();
            catalog.LoadFromSQLite();
            var loadedCompositions = catalog.GetCatalog();

            // Assert
            Assert.Contains(composition1, loadedCompositions);
            Assert.Contains(composition2, loadedCompositions);
        }
    }
}
