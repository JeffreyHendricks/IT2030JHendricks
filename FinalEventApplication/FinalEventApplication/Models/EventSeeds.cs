using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.Validation;

namespace FinalEventApplication.Models
{
    public class EventSeeds : DropCreateDatabaseIfModelChanges<FinalEventApplicationDBContext>
    {
        protected override void Seed(FinalEventApplicationDBContext db)
        {
            var eventTypes = new List<EventType>
            {
                new EventType {EventTypeTitle="Game Tournament", EventTypeDescription="Competitions for gamers."},
                new EventType {EventTypeTitle="Game Expo", EventTypeDescription="Conventions to show new games and give information on them."},
                new EventType {EventTypeTitle="Game Night", EventTypeDescription="A planned night of gaming for anyone invited."},
                new EventType {EventTypeTitle="Game Creation Expo", EventTypeDescription="Conventions for game creators to meet and give information to eachother and the public regarding their games."},
                new EventType {EventTypeTitle="GamerTag Rewrite", EventTypeDescription="An event to meet up with other gamers and talk about their gamer names and share ideas."},
                new EventType {EventTypeTitle="Anime Cosplay Contest", EventTypeDescription="An event for people to meet and dress in Cosplay of their favorite game and anime characters."},
                new EventType {EventTypeTitle="Anime Marathon", EventTypeDescription="An event to plan a long showing of an series or genre of anime."},
                new EventType {EventTypeTitle="Future Anime-tors", EventTypeDescription="An event for future anime artist and story-boardist to meet and talk about their ideas and future plans. "},
                new EventType {EventTypeTitle="Anime Expo", EventTypeDescription="Convention for fans and artists alike to gain information on new and old anime."},
                new EventType {EventTypeTitle="Anime Artwork", EventTypeDescription="An event for artists to show off their anime artwork."}
            };

            var events = new List<Event>
            {
                new Event {Title="20 Gigs of fun", EventDescription="An exposition for all the latest games and fans.", EventTypeTitle= "Game Expo", StartDate= new DateTime(2018,11,05), EndDate= new DateTime(2018,11,06) ,  Location="Cleveland", OrganizerName="Jeffrey Hendricks", MaxTickets= 20, AvailableTickets= 15, EventArtUrl=""},
                new Event {Title="Beta Bring A Computer", EventTypeTitle="Game Expo", EventDescription="'The' exposition to be at for computer gamers.", StartDate= new DateTime(2018,12,01), EndDate= new DateTime(2018, 12,03) ,  Location="NorthPole", OrganizerName="SantyClaws", MaxTickets=15, AvailableTickets= 15, EventArtUrl=""},
                new Event {Title="2018 Recap Expo", EventTypeTitle="Game Expo", EventDescription="An exposition to look back at all the conventions this year", StartDate= new DateTime(2018, 10, 31), EndDate= new DateTime(2018, 11, 01) ,  Location="Chesapeake", OrganizerName="Mandy Wandy", MaxTickets= 10, AvailableTickets= 10, EventArtUrl=""},
                new Event {Title="Smash Bros Mash-up", EventTypeTitle="Game Tournament", EventDescription="A serious tournament for competitive Smah Bros players. ", StartDate= new DateTime(2018, 09, 10), EndDate= new DateTime(2018, 12, 12),  Location="Los Angeles", OrganizerName="Zero Sheik", MaxTickets= 12, AvailableTickets= 2, EventArtUrl=""},
                new Event {Title="Melee Mania", EventTypeTitle="Game Tournament", EventDescription="A fun tournament from an older Smash Bros game.", StartDate= new DateTime(2018, 08, 11), EndDate= new DateTime(2018, 08, 13),  Location="Chicago", OrganizerName="Sum Budy", MaxTickets= 15, AvailableTickets= 10, EventArtUrl=""},
                new Event {Title="Mario Party Extra++", EventTypeTitle="Game Tournament", EventDescription="Friendly tournament using the Mario Party game, for friends to enjoy.", StartDate= new DateTime(2018, 11, 12), EndDate= new DateTime(2018, 11, 13),  Location="Pittsburgh", OrganizerName="Steve Een", MaxTickets=10, AvailableTickets= 5, EventArtUrl=""},
                new Event {Title="Bored Games To Board Games", EventTypeTitle="Game Night", EventDescription="A friendly night of board games.", StartDate= new DateTime(2018, 12, 15), EndDate= new DateTime(2018, 12, 16),  Location="Springfield", OrganizerName="Antony Antilla", MaxTickets= 20, AvailableTickets= 20, EventArtUrl=""},
                new Event {Title="Magic The Gathering...Nuff Said", EventTypeTitle="Game Night", EventDescription="A night of Magic cards with friends.", StartDate= new DateTime(2018, 12, 18), EndDate= new DateTime(2018, 12, 18),  Location="Akron", OrganizerName="Jerry Sully", MaxTickets= 15, AvailableTickets= 10, EventArtUrl=""},
                new Event {Title="Cards Against Humanity Night", EventTypeTitle="Game Night", EventDescription="A night of cards for adults.", StartDate= new DateTime(2018, 12, 24), EndDate= new DateTime(2018, 12, 26),  Location="Gotham", OrganizerName="Jack Mehoff", MaxTickets=15, AvailableTickets= 10, EventArtUrl=""},
                new Event {Title="G.C.E. First Edition", EventTypeTitle="Game Creation Expo", EventDescription="The first Game Creators Expo of many.", StartDate= new DateTime(2018, 12, 13), EndDate= new DateTime(2018, 12, 14),  Location="Miami", OrganizerName="Brody Bony", MaxTickets=15, AvailableTickets= 15, EventArtUrl=""},
                new Event {Title="Gamers United", EventTypeTitle="Game Creation Expo", EventDescription="An exposition for game creators to meet and show off their work.", StartDate= new DateTime(2018,12,14), EndDate= new DateTime(2018,12,15),  Location="Boston", OrganizerName="Alexander Hambrone", MaxTickets=20, AvailableTickets= 18, EventArtUrl=""},
                new Event {Title="All For One...Game", EventTypeTitle="Game Creation Expo", EventDescription="An exposition for gamers to meet and collaborate on one topic.", StartDate= new DateTime(2018,12,17), EndDate= new DateTime(2018,12,18),  Location="NewYork City", OrganizerName="Broseidon Ocean", MaxTickets=25, AvailableTickets= 15, EventArtUrl=""},
                new Event {Title="GamerTag Distortion", EventTypeTitle="GamerTag Rewrite", EventDescription="A chance to meet up with other gamers and discuss your tag.", StartDate= new DateTime(2018,12,20), EndDate= new DateTime(2018,12,25),  Location="Orlando", OrganizerName="Jilly Silly", MaxTickets=18, AvailableTickets= 10, EventArtUrl=""},
                new Event {Title="Gamer Name Revolution", EventTypeTitle="GamerTag Rewrite", EventDescription="A chance to take advice on how your name is impacting your gaming experience.", StartDate= new DateTime(2018,12,28), EndDate= new DateTime(2018,12,29),  Location="Portland", OrganizerName="Atsuko Mystery", MaxTickets=15, AvailableTickets= 5, EventArtUrl=""},
                new Event {Title="G.T.Remix", EventTypeTitle="GamerTag Rewrite", EventDescription="An event for people to meet up and discuss changing their tag and following through with it.", StartDate= new DateTime(2018,12,15), EndDate= new DateTime(2018,12,17),  Location="Tokyo", OrganizerName="Jenna White", MaxTickets=20, AvailableTickets= 2, EventArtUrl=""},
                new Event {Title="Earth To RayEarth", EventTypeTitle="Anime Expo", EventDescription="An exposition on the anime RayEarth.", StartDate= new DateTime(2018,12,7), EndDate= new DateTime(2018,12,9),  Location="Charlotte", OrganizerName="Jeffrey White", MaxTickets=30, AvailableTickets= 15, EventArtUrl="~/Content/Images/RayEarth.jpg"},
                new Event {Title="Otakus Collide", EventTypeTitle="Anime Expo", EventDescription="An exposition for otakus to learn about one another and share friendly information.", StartDate= new DateTime(2018,12,16), EndDate= new DateTime(2018,12,18),  Location="Virginia Beach", OrganizerName="Joseph Acord", MaxTickets=14, AvailableTickets= 4, EventArtUrl=""},
                new Event {Title="Antagonist's United", EventTypeTitle="Anime Expo", EventDescription="An exposition to talk about the antagonists of animes and how they impacted the overall feel of the anime.", StartDate= new DateTime(2018,12,31), EndDate= new DateTime(2019,01,01),  Location="San Joaquin", OrganizerName="Kanu Devalil", MaxTickets=10, AvailableTickets= 10, EventArtUrl=""},
                new Event {Title="YUYU....You should watch this", EventTypeTitle="Anime Marathon", EventDescription="A marathon on the YuYu Hakusho anime.", StartDate= new DateTime(2019,01,02), EndDate= new DateTime(2019,01,03),  Location="Central City", OrganizerName="Sean John", MaxTickets=15, AvailableTickets= 5, EventArtUrl=""},
                new Event {Title="80's Glamorous Anime", EventTypeTitle="Anime Marathon", EventDescription="A marathon of anime from the 1980's.", StartDate= new DateTime(2019,01,04), EndDate= new DateTime(2019,01,05),  Location="Compton", OrganizerName="Tommy Hillfigure", MaxTickets=19, AvailableTickets= 6, EventArtUrl=""},
                new Event {Title="Anime Horror Shows", EventTypeTitle="Anime Marathon", EventDescription="A marathon of anime within the horror genre.", StartDate= new DateTime(2019,01,06), EndDate= new DateTime(2019,01,07),  Location="San Fransisco", OrganizerName="Mai Cao", MaxTickets=25, AvailableTickets= 20, EventArtUrl=""},
                new Event {Title="Cosplay All Day", EventTypeTitle="Anime Cosplay Contest", EventDescription="A chance to show off your cosplay in front of other fans.", StartDate= new DateTime(2019,01,08), EndDate= new DateTime(2019,01,09),  Location="Las Vegas", OrganizerName="Jenny Espinosa", MaxTickets=30, AvailableTickets= 25, EventArtUrl=""},
                new Event {Title="Chillin Like A Super Villain", EventTypeTitle="Anime Cosplay Contest", EventDescription="Dress up as your favorite super villain for this cosplay event.", StartDate= new DateTime(2019,1,10), EndDate= new DateTime(2019,01,11),  Location="Ocean City", OrganizerName="Huiyu Wu", MaxTickets=15, AvailableTickets= 7, EventArtUrl=""},
                new Event {Title="Waifu's For Life....u?", EventTypeTitle="Anime Cosplay Contest", EventDescription="Cosplay as your favorite anime (dream wife).", StartDate= new DateTime(2019,2,1), EndDate= new DateTime(2019,02,02),  Location="Mexico City", OrganizerName="Adeline Wisernig", MaxTickets=18, AvailableTickets= 8, EventArtUrl=""},
                new Event {Title="Future Anime Endeavors", EventTypeTitle="Future Anime-tors", EventDescription="An event for future anime artists and writers to trade information and ideas.", StartDate= new DateTime(2019,02,14), EndDate= new DateTime(2019,02,15),  Location="Columbus", OrganizerName="Justin Adkins", MaxTickets=20, AvailableTickets= 16, EventArtUrl=""},
                new Event {Title="Fandoms For Future Seasons", EventTypeTitle="Future Anime-tors", EventDescription="An event for fans of an anime to meet up and talk about what they assume for a future season of an anime.", StartDate= new DateTime(2019,04,20), EndDate= new DateTime(2019,04,21),  Location="Cincinatti", OrganizerName="Brooke Farmer", MaxTickets=18, AvailableTickets= 9, EventArtUrl=""},
                new Event {Title="Say It Loudly, Write It Proudly", EventTypeTitle="Future Anime-tors", EventDescription="A seminar for anime writers to talk and trade ideas and write it out.", StartDate= new DateTime(2019,02,09), EndDate= new DateTime(2019,02,10),  Location="Kent", OrganizerName="Trina Hendricks", MaxTickets=17, AvailableTickets= 15, EventArtUrl=""},
                new Event {Title="Aesthetic Anime", EventTypeTitle="Anime Artwork", EventDescription="A panel to show off artwork of an anime drawn differently in appealing ways.", StartDate= new DateTime(2019,07,12), EndDate= new DateTime(2019,07,13),  Location="Lakewood", OrganizerName="Richard Hendricks Sr.", MaxTickets=12, AvailableTickets= 8, EventArtUrl=""},
                new Event {Title="All The Anime", EventTypeTitle="Anime Artwork", EventDescription="An event to show off artwork from every popular anime of this year.", StartDate= new DateTime(2019,07,03), EndDate= new DateTime(2019,07,04),  Location="North Olmsted", OrganizerName="Junna Yamamoto", MaxTickets=21, AvailableTickets= 6, EventArtUrl=""},
                new Event {Title="My Art My Perspective", EventTypeTitle="Anime Artwork", EventDescription="An artists take on anime and their interpreted drawings.", StartDate= new DateTime(2019,07,19), EndDate= new DateTime(2019,07,20),  Location="Strongsville", OrganizerName="Evan Someone", MaxTickets=23, AvailableTickets= 7, EventArtUrl=""}
            };
            events.ForEach(e => db.Events.Add(e));
            db.SaveChanges();
            
        }
    }
}