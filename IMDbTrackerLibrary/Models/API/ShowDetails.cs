﻿namespace IMDbTrackerLibrary.Models.API {

    public class ShowDetails {
        public string Id { get; set; }
        public ShowTitle Title { get; set; }
        public ShowRatings Ratings { get; set; }
        public string[] Genres { get; set; }
        public string ReleaseDate { get; set; }
        public ShowPlotoutline PlotOutline { get; set; }
        public ShowPlotsummary PlotSummary { get; set; }
    }

    public class ShowTitle {
        public ShowImage Image { get; set; }
        public int RunningTimeInMinutes { get; set; }
        public int NumberOfEpisodes { get; set; }
        public int SeriesEndYear { get; set; }
        public int SeriesStartYear { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
    }

    public class ShowImage {
        public string Url { get; set; }
    }

    public class ShowRatings {
        public float Rating { get; set; }
    }

    public class ShowPlotoutline {
        public string Text { get; set; }
    }

    public class ShowPlotsummary {
        public string Text { get; set; }
    }

}
