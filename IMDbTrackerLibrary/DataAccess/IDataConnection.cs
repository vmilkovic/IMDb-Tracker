﻿using IMDbTrackerLibrary.Models;
using System.Collections.Generic;

namespace IMDbTrackerLibrary.DataAccess {
    public interface IDataConnection {
        void CreateTables();
        void CreateUser(User model);
        void UpdateUser(User model);
        void DeleteUser(User model);
        User FindUserByUsername(string username);
        User FindUserByEmail(string email);
        bool UsernameExists(string username);
        bool EmailExists(string email, int userId);
        bool APIKeyExists(string apiKey, int userId);
        void SetPasswordResetToken(User model, string passwordResetKey, System.DateTime passwordResetTokenValid);
        (string, System.DateTime?) GetPasswordResetToken(User model);
        void AddShow(Show model);
        void AddShows(List<Show> shows);
        Show FindShowById(string showId);
        void AddEpisode(Episode model);
        void AddEpisodes(List<Episode> episodes);
        Episode FindEpisodeById(string episodeId);
        void AddMovie(Movie model);
        void AddMovies(List<Movie> movies);
        Movie FindMovieById(string movieId);
        void AddFavoriteShow(FavoriteShow model);
        void RemoveFavoriteShow(FavoriteShow model);
        FavoriteShow FindFavoriteShowByIds(FavoriteShow model);
        List<FavoriteShow> FindUserFavoriteShows(User model);
        void AddFavoriteMovie(FavoriteMovie model);
        void RemoveFavoriteMovie(FavoriteMovie model);
        FavoriteMovie FindFavoriteMovieByIds(FavoriteMovie model);
        List<FavoriteMovie> FindUserFavoriteMovies(User model);
        void AddShowComment(ShowComment model);
        void UpdateShowComment(ShowComment model);
        ShowComment FindShowComment(Show show, User user);
        void AddEpisodeComment(EpisodeComment model);
        void UpdateEpisodeComment(EpisodeComment model);
        EpisodeComment FindEpisodeComment(Episode epside, User user);
        void AddMovieComment(MovieComment model);
        void UpdateMovieComment(MovieComment model);
        MovieComment FindMovieComment(Movie movie, User user);
    }
}
