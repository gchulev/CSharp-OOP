// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to Festival Manager (entities/controllers/etc)
// Test ONLY the Stage class. 
namespace FestivalManager.Tests
{
    using FestivalManager.Entities;

    using NUnit.Framework;

    using System;

    [TestFixture]
    public class StageTests
    {
        [Test]
        public void MethodAddPerformerShouldThrowAnExceptionWhenAgeIsUnder18()
        {
            // Arrange
            Stage stage = new Stage();
            Performer performer1 = new Performer("Performer1", "Test1", 20);
            Performer performer2 = new Performer("Performer2", "Test2", 17);

            // Act
            stage.AddPerformer(performer1);

            // Assert
            Assert.Throws<ArgumentException>(() =>
            {
                stage.AddPerformer(performer2);
            }, "You can only add performers that are at least 18.");
        }

        [Test]
        public void PropertyPerformersShouldReturnTheCorrectNumberOfPerformers()
        {
            // Arrange
            Stage stage = new Stage();
            Performer performer1 = new Performer("Performer1", "Test1", 20);
            Performer performer2 = new Performer("Performer2", "Test2", 18);

            // Act
            stage.AddPerformer(performer2);
            stage.AddPerformer(performer1);

            // Assert
            Assert.That(stage.Performers.Count, Is.EqualTo(2), "Wrong perfomarce count!");
        }

        [Test]
        public void AddSongMethodShouldThrowExceptionWhenSongDurationIsBelowOneMinute()
        {
            // Arrange
            Stage stage = new Stage();
            Song song1 = new Song("Song1", new TimeSpan(0, 0, 59));

            // Act & Assert
            Assert.Throws<ArgumentException>(() =>
            {
                stage.AddSong(song1);
            }, "You can only add songs that are longer than 1 minute.");
        }

        [Test]
        public void AddSongMethodShouldThrowExceptionIfSongIsNull()
        {
            // Arrange
            Stage stage = new Stage();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() =>
            {
                stage.AddSong(null);
            }, "Can not be null!");
        }
        [Test]

        public void AddSongToPerformerShouldThrowExceptionIfInvalidSongOrPerfomerIsProvided()
        {
            // Arrange
            Stage stage = new Stage();
            Performer performer1 = new Performer("Performer1", "Test1", 20);
            Song song1 = new Song("Song1", new TimeSpan(0, 2, 59));

            // Act
            stage.AddSong(song1);
            stage.AddPerformer(performer1);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.Throws<ArgumentException>(() =>
                {
                    stage.AddSongToPerformer("", performer1.FullName);
                }, "There is no song with this name.");

                Assert.Throws<ArgumentException>(() =>
                {
                    stage.AddSongToPerformer(song1.Name, "");
                }, "There is no performer with this name.");
            });
        }

        [Test]
        public void AddSongToPerformerShouldReturnCorrectSongNameAndPerformerName()
        {
            // Arrange
            Stage stage = new Stage();
            Performer performer1 = new Performer("Performer1", "Test1", 20);
            Song song1 = new Song("Song1", new TimeSpan(0, 2, 59));

            // Act
            stage.AddSong(song1);
            stage.AddPerformer(performer1);
            string actualResult = stage.AddSongToPerformer(song1.Name, performer1.FullName);

            // Assert
            Assert.That(actualResult, Is.EqualTo($"Song1 (02:59) will be performed by Performer1 Test1"));
        }

        [Test]
        public void PlayMethodShouldWorkCorrectly()
        {
            // Arrange
            Stage stage = new Stage();

            Performer performer1 = new Performer("Performer1", "Test1", 20);
            Performer performer2 = new Performer("Performer2", "Test2", 29);

            Song song1 = new Song("Song1", new TimeSpan(0, 2, 59));
            Song song2 = new Song("Song2", new TimeSpan(0, 4, 29));
            Song song3 = new Song("Song3", new TimeSpan(0, 3, 18));
            Song song4 = new Song("Song4", new TimeSpan(0, 5, 09));

            // Act
            stage.AddSong(song1);
            stage.AddSong(song2);
            stage.AddSong(song3);
            stage.AddSong(song4);

            stage.AddPerformer(performer1);
            stage.AddPerformer(performer2);

            stage.AddSongToPerformer(song1.Name, performer1.FullName);
            stage.AddSongToPerformer(song2.Name, performer1.FullName);
            stage.AddSongToPerformer(song3.Name, performer1.FullName);
            stage.AddSongToPerformer(song4.Name, performer2.FullName);

            string expectedResult = stage.Play();

            // Assert
            Assert.That(expectedResult, Is.EqualTo($"2 performers played 4 songs"));
        }

    }
}