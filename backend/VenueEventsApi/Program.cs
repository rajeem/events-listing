using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;
using VenueEventsApi.Application.Interfaces;
using VenueEventsApi.Application.Services;
using VenueEventsApi.Domain.Entities;
using VenueEventsApi.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("VenueEventsDB"));
builder.Services.AddScoped<IVenueEventsService, VenueEventsService>();
builder.Services.AddScoped<IVenuesService, VenuesService>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

var app = builder.Build();
app.UseCors("AllowAll");


SeedSampleData(app);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

static void SeedSampleData(WebApplication app)
{
    using (var scope = app.Services.CreateScope())
    {
        var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        
        dbContext.Venues!.AddRange(
            new Venue
            {
                Id = 121,
                Name = "The Coding Theatre",
                Capacity = 450,
                Location = "TEG Metaverse"
            },
            new Venue {
                Id = 123,
                Name = "TEG Stadium",
                Capacity = 65000,
                Location = "London, UK"
            },
            new Venue {
                Id = 125,
                Name = "TEG Office Level 14",
                Capacity = 56,
                Location = "Sydney, Australia"
            },
            new Venue {
                Id = 919,
                Name = "The TEG Observatory",
                Capacity = 150,
                Location = "Auckland, New Zealand"
            },
            new Venue {
                Id = 10029,
                Name = "TEG Technology Museum",
                Capacity = 600,
                Location = "Singapore"
            });
        dbContext.SaveChanges();

        dbContext.Events!.AddRange(
            new VenueEvent
            {
                Id = 10000,
                Name = "10cc In Concert",
                StartDate = DateTime.Parse("2022-11-10T12:00:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 121
            }, new VenueEvent
            {
                Id = 10001,
                Name = "Johnny Cash The Concert",
                StartDate = DateTime.Parse("2023-03-03T12:00:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 123
            }, new VenueEvent
            {
                Id = 10002,
                Name = "Play School Live in Concert",
                StartDate = DateTime.Parse("2022-10-05T23:00:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 123
            }, new VenueEvent
            {
                Id = 10003,
                Name = "The Guilty Feminist Live Podcast",
                StartDate = DateTime.Parse("2022-07-13T10:30:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 919
            }, new VenueEvent
            {
                Id = 10004,
                Name = "Dirty Dancing In Concert",
                StartDate = DateTime.Parse("2022-06-10T10:00:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 125
            }, new VenueEvent
            {
                Id = 10005,
                Name = "Dirty Dancing In Concert",
                StartDate = DateTime.Parse("2022-06-11T10:00:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 125
            }, new VenueEvent
            {
                Id = 10006,
                Name = "Dirty Dancing In Concert",
                StartDate = DateTime.Parse("2022-06-25T10:00:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 10029
            }, new VenueEvent
            {
                Id = 10007,
                Name = "Dirty Dancing In Concert",
                StartDate = DateTime.Parse("2022-06-25T05:30:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 10029
            }, new VenueEvent
            {
                Id = 10008,
                Name = "Dirty Dancing In Concert",
                StartDate = DateTime.Parse("2022-06-18T10:00:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 125
            }, new VenueEvent
            {
                Id = 10009,
                Name = "Dirty Dancing In Concert",
                StartDate = DateTime.Parse("2022-06-18T05:30:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 10029
            }, new VenueEvent
            {
                Id = 10010,
                Name = "Encore! Eric Bogle & Friends In Concert",
                StartDate = DateTime.Parse("2022-06-24T09:30:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 123
            }, new VenueEvent
            {
                Id = 10011,
                Name = "NSGHS SHOWCASE CONCERT",
                StartDate = DateTime.Parse("2022-06-29T08:30:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 123
            }, new VenueEvent
            {
                Id = 10012,
                Name = "Rob Beckett - Wallop",
                StartDate = DateTime.Parse("2022-11-21T09:30:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 125
            }, new VenueEvent
            {
                Id = 10013,
                Name = "Always Bon Jovi",
                Description = "Always Bon Jovi     Australia’s optimum Bon Jovi Tribute Show     This Sydney Rock band delivers the power, passion, and high Energy synonymous with the unique Sambora / Bon Jovi combination.     This authentic live show replicates the complete Bon Jovi concert experience. It is artistically clever, visually pleasing, and vocally exciting.     Musical highlights include, Living on A Prayer, Wanted Dead or Alive, It’s My Life, Have A Nice Day & many more.     5 of Sydney’s premier musicians with over 70 years combined experience bring to you a concert you will not forget.",
                StartDate = DateTime.Parse("2022-10-15T09:00:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 121
            }, new VenueEvent
            {
                Id = 10014,
                Name = "Last Podcast On The Left",
                StartDate = DateTime.Parse("2023-01-20T09:30:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 123
            }, new VenueEvent
            {
                Id = 10015,
                Name = "Midori Takada",
                StartDate = DateTime.Parse("2022-06-09T09:30:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 123
            }, new VenueEvent
            {
                Id = 10016,
                Name = "Masego ",
                StartDate = DateTime.Parse("2022-06-10T09:00:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 121
            }, new VenueEvent
            {
                Id = 10017,
                Name = "IDLES",
                StartDate = DateTime.Parse("2022-10-31T09:00:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 10029
            }, new VenueEvent
            {
                Id = 10018,
                Name = "IDLES",
                StartDate = DateTime.Parse("2022-11-01T09:00:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 125
            }, new VenueEvent
            {
                Id = 10019,
                Name = "Steve Hackett",
                Description = "Steve Hackett, as the powerhouse guitarist for one of the most important progressive rock bands ever, has been a guiding influence for musicians and guitarists for over 40 years.    Following the one/two punch of “Nursery Cryme” & “Foxtrot”, both driven by the muscular guitars of new member Steve Hackett, Genesis were ready to launch what would become their finest album, “Selling England By The Pound”.    Easing back on the throttle marginally, and immersing themselves in English whimsy and eccentricity, Genesis delivered just under an hour of delicate prose, wondrous melodies and, of course, the soaring leadlines of Steve Hackett.    Finally, now, 47 years after the album’s release, Steve Hackett will be performing “Selling England By The Pound” in full in a series of Australian and New Zealand concerts.    “I think (Genesis) really nailed the best of what that band as an entity could have done with that album.” Neil Peart (Rush)    \"… a complexity of tone that's pretty rare in any kind of art.\" Robert Christgau    “the definitive Genesis album” Fish (formerly of Marillion)    In addition, in celebration of the 40th anniversary of its release, Steve will be performing his critically acclaimed solo album “Spectral Mornings”.    “Spectral Mornings is a superb disc from one of the genre's all-time greatest guitarists. Five stars!” Prog archives    And if that’s not enough, Steve will perform selections from his stunning new album “At The Edge Of Light”, and may even be munificent enough to throw in another couple of Genesis tunes.    “I’m excited to bring my Genesis Revisited show back to Australia and New Zealand. It was fantastic to play there last time and to visit those amazing countries. This time will be a special show, including the whole of Genesis album Selling England by the Pound, celebrating my solo album Spectral Mornings 40th anniversary, plus more! I can’t wait!” Steve Hackett",
                StartDate = DateTime.Parse("2022-06-22T10:00:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 121
            }, new VenueEvent
            {
                Id = 10020,
                Name = "Jagged Little Pill",
                StartDate = DateTime.Parse("2022-07-09T09:30:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 121
            }, new VenueEvent
            {
                Id = 10021,
                Name = "Jagged Little Pill",
                StartDate = DateTime.Parse("2022-07-10T08:00:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 125
            }, new VenueEvent
            {
                Id = 10022,
                Name = "Jagged Little Pill",
                StartDate = DateTime.Parse("2022-07-12T09:00:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 10029
            }, new VenueEvent
            {
                Id = 10023,
                Name = "Jagged Little Pill",
                StartDate = DateTime.Parse("2022-07-13T09:30:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 125
            }, new VenueEvent
            {
                Id = 10024,
                Name = "Jagged Little Pill",
                StartDate = DateTime.Parse("2022-07-14T09:30:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 125
            }, new VenueEvent
            {
                Id = 10025,
                Name = "Jagged Little Pill",
                StartDate = DateTime.Parse("2022-07-15T09:30:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 10029
            }, new VenueEvent
            {
                Id = 10026,
                Name = "Jagged Little Pill",
                StartDate = DateTime.Parse("2022-07-16T09:30:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 121
            }, new VenueEvent
            {
                Id = 10027,
                Name = "Jagged Little Pill",
                StartDate = DateTime.Parse("2022-07-16T04:00:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 919
            }, new VenueEvent
            {
                Id = 10028,
                Name = "Jagged Little Pill",
                StartDate = DateTime.Parse("2022-07-17T03:00:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 125
            }, new VenueEvent
            {
                Id = 10029,
                Name = "Jagged Little Pill",
                StartDate = DateTime.Parse("2022-07-19T09:00:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 123
            }, new VenueEvent
            {
                Id = 10030,
                Name = "Jagged Little Pill",
                StartDate = DateTime.Parse("2022-07-20T09:30:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 121
            }, new VenueEvent
            {
                Id = 10031,
                Name = "Jagged Little Pill",
                StartDate = DateTime.Parse("2022-07-21T09:30:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 919
            }, new VenueEvent
            {
                Id = 10032,
                Name = "Jagged Little Pill",
                StartDate = DateTime.Parse("2022-07-22T09:30:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 123
            }, new VenueEvent
            {
                Id = 10033,
                Name = "Jagged Little Pill",
                StartDate = DateTime.Parse("2022-07-23T09:30:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 919
            }, new VenueEvent
            {
                Id = 10034,
                Name = "Jagged Little Pill",
                StartDate = DateTime.Parse("2022-07-23T04:00:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 919
            }, new VenueEvent
            {
                Id = 10035,
                Name = "Jagged Little Pill",
                StartDate = DateTime.Parse("2022-07-24T03:00:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 10029
            }, new VenueEvent
            {
                Id = 10036,
                Name = "Jagged Little Pill",
                StartDate = DateTime.Parse("2022-07-26T09:00:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 10029
            }, new VenueEvent
            {
                Id = 10037,
                Name = "Jagged Little Pill",
                StartDate = DateTime.Parse("2022-07-27T09:30:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 10029
            }, new VenueEvent
            {
                Id = 10038,
                Name = "Jagged Little Pill",
                StartDate = DateTime.Parse("2022-07-28T09:30:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 125
            }, new VenueEvent
            {
                Id = 10039,
                Name = "Jagged Little Pill",
                StartDate = DateTime.Parse("2022-07-29T09:30:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 123
            }, new VenueEvent
            {
                Id = 10040,
                Name = "Jagged Little Pill",
                StartDate = DateTime.Parse("2022-07-30T09:30:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 10029
            }, new VenueEvent
            {
                Id = 10041,
                Name = "Jagged Little Pill",
                StartDate = DateTime.Parse("2022-07-30T04:00:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 121
            }, new VenueEvent
            {
                Id = 10042,
                Name = "Jagged Little Pill",
                StartDate = DateTime.Parse("2022-07-31T03:00:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 125
            }, new VenueEvent
            {
                Id = 10043,
                Name = "Jagged Little Pill",
                StartDate = DateTime.Parse("2022-08-02T09:00:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 919
            }, new VenueEvent
            {
                Id = 10044,
                Name = "Jagged Little Pill",
                StartDate = DateTime.Parse("2022-08-03T09:30:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 121
            }, new VenueEvent
            {
                Id = 10045,
                Name = "Jagged Little Pill",
                StartDate = DateTime.Parse("2022-08-04T09:30:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 123
            }, new VenueEvent
            {
                Id = 10046,
                Name = "Jagged Little Pill",
                StartDate = DateTime.Parse("2022-08-05T09:30:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 919
            }, new VenueEvent
            {
                Id = 10047,
                Name = "Jagged Little Pill",
                StartDate = DateTime.Parse("2022-08-06T09:30:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 125
            }, new VenueEvent
            {
                Id = 10048,
                Name = "Jagged Little Pill",
                StartDate = DateTime.Parse("2022-08-06T04:00:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 123
            }, new VenueEvent
            {
                Id = 10049,
                Name = "Jagged Little Pill",
                StartDate = DateTime.Parse("2022-08-07T03:00:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 125
            }, new VenueEvent
            {
                Id = 10050,
                Name = "Jagged Little Pill",
                StartDate = DateTime.Parse("2022-08-09T09:00:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 123
            }, new VenueEvent
            {
                Id = 10051,
                Name = "Jagged Little Pill",
                StartDate = DateTime.Parse("2022-08-10T09:30:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 123
            }, new VenueEvent
            {
                Id = 10052,
                Name = "Jagged Little Pill",
                StartDate = DateTime.Parse("2022-08-11T09:30:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 919
            }, new VenueEvent
            {
                Id = 10053,
                Name = "Jagged Little Pill",
                StartDate = DateTime.Parse("2022-08-12T09:30:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 10029
            }, new VenueEvent
            {
                Id = 10054,
                Name = "Jagged Little Pill",
                StartDate = DateTime.Parse("2022-08-13T09:30:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 919
            }, new VenueEvent
            {
                Id = 10055,
                Name = "Jagged Little Pill",
                StartDate = DateTime.Parse("2022-08-13T04:00:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 125
            }, new VenueEvent
            {
                Id = 10056,
                Name = "Jagged Little Pill",
                StartDate = DateTime.Parse("2022-08-14T03:00:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 125
            }, new VenueEvent
            {
                Id = 10057,
                Name = "Jagged Little Pill",
                StartDate = DateTime.Parse("2022-08-16T09:00:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 121
            }, new VenueEvent
            {
                Id = 10058,
                Name = "Jagged Little Pill",
                StartDate = DateTime.Parse("2022-08-17T09:30:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 919
            }, new VenueEvent
            {
                Id = 10059,
                Name = "Jagged Little Pill",
                StartDate = DateTime.Parse("2022-08-18T09:30:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 123
            }, new VenueEvent
            {
                Id = 10060,
                Name = "Jagged Little Pill",
                StartDate = DateTime.Parse("2022-08-19T09:30:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 121
            }, new VenueEvent
            {
                Id = 10061,
                Name = "Jagged Little Pill",
                StartDate = DateTime.Parse("2022-08-20T09:30:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 919
            }, new VenueEvent
            {
                Id = 10062,
                Name = "Jagged Little Pill",
                StartDate = DateTime.Parse("2022-08-20T04:00:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 10029
            }, new VenueEvent
            {
                Id = 10063,
                Name = "Jagged Little Pill",
                StartDate = DateTime.Parse("2022-08-21T03:00:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 10029
            }, new VenueEvent
            {
                Id = 10064,
                Name = "LETZ ZEP",
                StartDate = DateTime.Parse("2022-11-11T09:00:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 125
            }, new VenueEvent
            {
                Id = 10065,
                Name = "HONNE",
                StartDate = DateTime.Parse("2022-09-22T10:15:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 125
            }, new VenueEvent
            {
                Id = 10066,
                Name = "Marisa Anderson and Jim White",
                StartDate = DateTime.Parse("2022-06-09T07:00:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 919
            }, new VenueEvent
            {
                Id = 10067,
                Name = "CHAI and Buffalo Daughter ",
                StartDate = DateTime.Parse("2022-06-11T09:00:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 10029
            }, new VenueEvent
            {
                Id = 10068,
                Name = "AJ Tracey",
                StartDate = DateTime.Parse("2022-09-21T09:00:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 125
            }, new VenueEvent
            {
                Id = 10069,
                Name = "HONNE",
                StartDate = DateTime.Parse("2022-09-23T10:00:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 125
            }, new VenueEvent
            {
                Id = 10070,
                Name = "Big Thief",
                StartDate = DateTime.Parse("2022-11-23T08:00:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 123
            }, new VenueEvent
            {
                Id = 10071,
                Name = "Big Thief",
                StartDate = DateTime.Parse("2022-11-24T08:45:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 10029
            }, new VenueEvent
            {
                Id = 10072,
                Name = "Satinder Sartaaj",
                StartDate = DateTime.Parse("2022-07-23T11:00:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 10029
            }, new VenueEvent
            {
                Id = 10073,
                Name = "1927",
                StartDate = DateTime.Parse("2022-06-18T09:30:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 123
            }, new VenueEvent
            {
                Id = 10074,
                Name = "East Meets West Orchestral Concert",
                StartDate = DateTime.Parse("2022-11-17T09:00:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 123
            }, new VenueEvent
            {
                Id = 10075,
                Name = "East Meets West Orchestral Concert",
                StartDate = DateTime.Parse("2022-07-30T09:30:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 123
            }, new VenueEvent
            {
                Id = 10076,
                Name = "The Whitlams",
                StartDate = DateTime.Parse("2022-09-29T11:30:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 121
            }, new VenueEvent
            {
                Id = 10077,
                Name = "Sunset Sounds",
                StartDate = DateTime.Parse("2022-11-05T05:30:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 10029
            }, new VenueEvent
            {
                Id = 10078,
                Name = "Running Touch \"Carmine\" Australian Tour 2022",
                StartDate = DateTime.Parse("2022-09-30T09:30:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 10029
            }, new VenueEvent
            {
                Id = 10079,
                Name = "Northlane",
                StartDate = DateTime.Parse("2022-06-18T09:00:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 10029
            }, new VenueEvent
            {
                Id = 10080,
                Name = "Northlane",
                StartDate = DateTime.Parse("2022-06-19T09:00:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 919
            }, new VenueEvent
            {
                Id = 10081,
                Name = "Passenger",
                StartDate = DateTime.Parse("2022-10-15T09:00:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 125
            }, new VenueEvent
            {
                Id = 10082,
                Name = "The King of Pop Show",
                StartDate = DateTime.Parse("2022-10-14T08:30:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 121
            }, new VenueEvent
            {
                Id = 10083,
                Name = "Aldous Harding ",
                StartDate = DateTime.Parse("2022-10-18T08:30:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 919
            }, new VenueEvent
            {
                Id = 10084,
                Name = "Arijit Singh",
                StartDate = DateTime.Parse("2022-07-17T09:30:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 919
            }, new VenueEvent
            {
                Id = 10085,
                Name = "Arijit Singh",
                StartDate = DateTime.Parse("2022-07-16T10:00:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 919
            }, new VenueEvent
            {
                Id = 10086,
                Name = "Whitney Orchestrated",
                StartDate = DateTime.Parse("2022-09-24T09:00:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 125
            }, new VenueEvent
            {
                Id = 10087,
                Name = "Whitney Orchestrated",
                StartDate = DateTime.Parse("2022-09-24T04:00:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 125
            }, new VenueEvent
            {
                Id = 10088,
                Name = "Black Veil Brides",
                StartDate = DateTime.Parse("2022-07-02T09:30:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 10029
            }, new VenueEvent
            {
                Id = 10089,
                Name = "Parisian Rhapsody",
                StartDate = DateTime.Parse("2022-10-08T08:00:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 121
            }, new VenueEvent
            {
                Id = 10090,
                Name = "Parisian Rhapsody",
                StartDate = DateTime.Parse("2022-10-09T03:00:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 919
            }, new VenueEvent
            {
                Id = 10091,
                Name = "Platinums x Premierships ",
                StartDate = DateTime.Parse("2022-06-19T09:30:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 121
            }, new VenueEvent
            {
                Id = 10092,
                Name = "ArrDee",
                StartDate = DateTime.Parse("2022-10-11T09:00:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 125
            }, new VenueEvent
            {
                Id = 10093,
                Name = "Sheku Kanneh-Mason & The Kanneh-Mason Family",
                StartDate = DateTime.Parse("2022-08-20T04:00:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 121
            }, new VenueEvent
            {
                Id = 10094,
                Name = "Sheku Kanneh-Mason & The Kanneh-Mason Family",
                StartDate = DateTime.Parse("2022-08-09T09:00:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 121
            }, new VenueEvent
            {
                Id = 10095,
                Name = "Sheku Kanneh-Mason & The Kanneh-Mason Family",
                StartDate = DateTime.Parse("2022-08-07T04:30:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 125
            }, new VenueEvent
            {
                Id = 10096,
                Name = "Harts Plays Hendrix",
                StartDate = DateTime.Parse("2022-10-07T09:00:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 10029
            }, new VenueEvent
            {
                Id = 10097,
                Name = "The Lord of The Rings & The Hobbit",
                StartDate = DateTime.Parse("2023-05-18T09:30:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 123
            }, new VenueEvent
            {
                Id = 10098,
                Name = "Cowboy Junkies",
                StartDate = DateTime.Parse("2023-02-10T11:00:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 919
            }, new VenueEvent
            {
                Id = 10099,
                Name = "The Amity Affliction",
                StartDate = DateTime.Parse("2022-07-12T08:30:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 123
            }, new VenueEvent
            {
                Id = 10100,
                Name = "The Amity Affliction",
                StartDate = DateTime.Parse("2022-07-13T08:30:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 919
            }, new VenueEvent
            {
                Id = 10101,
                Name = "The Jezabels",
                StartDate = DateTime.Parse("2022-06-24T09:30:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 123
            }, new VenueEvent
            {
                Id = 10102,
                Name = "Fontaines DC",
                StartDate = DateTime.Parse("2023-02-08T08:30:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 123
            }, new VenueEvent
            {
                Id = 10103,
                Name = "Superwog",
                StartDate = DateTime.Parse("2022-08-12T10:30:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 919
            }, new VenueEvent
            {
                Id = 10104,
                Name = "Shane Gillis",
                StartDate = DateTime.Parse("2022-08-10T10:30:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 125
            }, new VenueEvent
            {
                Id = 10105,
                Name = "Vir Das",
                StartDate = DateTime.Parse("2022-12-06T08:30:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 121
            }, new VenueEvent
            {
                Id = 10106,
                Name = "The Teskey Brothers with Orchestra Victoria",
                StartDate = DateTime.Parse("2022-11-18T08:30:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 121
            }, new VenueEvent
            {
                Id = 10107,
                Name = "The Whitlams",
                StartDate = DateTime.Parse("2022-09-24T09:00:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 123
            }, new VenueEvent
            {
                Id = 10108,
                Name = "SYNTHONY ",
                StartDate = DateTime.Parse("2022-06-17T11:00:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 10029
            }, new VenueEvent
            {
                Id = 10109,
                Name = "The Whitlams",
                StartDate = DateTime.Parse("2022-09-17T09:00:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 123
            }, new VenueEvent
            {
                Id = 10110,
                Name = "Marianas Trench",
                Description = "Support: Introvert    Canadian pop-rockers MARIANAS TRENCH will make a very welcome return to Australia’s east coast for a trio of explosive shows in April 2020 in support of their latest album release and iTunes Pop chart #1, Phantoms.    Completing epic treks across North America, UK and Europe, the Suspending Gravity Tour will touch down in Sydney’s Metro Theatre on April 5, ahead of performances at Download UK in June.    VIP Packages are also available including access to a special Q&A session and Meet & Greet with the band.    Hitting #1 on iTunes Pop chart here and in the USA, as well as their native Canada, Phantoms is Marianas Trench’s fifth studio album following their 2006 debut Fix Me, Masterpiece Theatre (2009), Ever After (2011) and Astoria (2015).    Marianas Trench draw on well-established strengths – their trademark, heavily layered harmonies, as well as blazing guitars set against club-worthy beats - but Phantoms also finds the Vancouver-based four-piece pushing their musical boundaries relentlessly. From the jaw-dropping opener, ‘Eleonora’ – a heavily layered a cappella salute to Edgar Allan Poe’s 1842 short story of the same name – to the unapologetically epic closer, ‘The Killing Kind’, with its deep orchestration, ripping guitars and vocal gymnastics.    “Each time we do an album, I try and write something that’s out of my vocal reach that forces me to get better,” says founding member and frontman Josh Ramsay, adding that bassist Mike Ayley, guitarist Matt Webb and drummer Ian Casselman, his “three favourite collaborators,” are equally dedicated to pushing their limits vocally and instrumentally - making for a dynamic live show.    VIP Package     One (1) General Admission standing ticket   Access to the Marianas Trench pre-show Q&A   Meet Marianas Trench for a photo opportunity by a professional photographer   Early Entry onto the floor prior to the general public   Exclusive Marianas Trench VIP merchandise item   Signed 8 x 10 photo of Marianas Trench   Early access to merchandise stand*   Designated VIP check-in and staff    *Venue dependant    VIP Nation Experience Terms & Conditions  Please ensure the contact details you provided at point of purchase are up to date. These will be the details used to communicate all VIP experience information.     Check-in location and time information will be emailed out by VIP Nation approximately 7 days prior to show day.   If you have not received this 5 days before the show please contact us immediately at mailto:VIP@livenation.com.au   Proof of purchase (confirmation email) will be required in order to check-in and receive your package benefits.   Experience details subject to change without notice.   NO REFUNDS will be given under any circumstances except in the case of concert/entire program cancellation.   If applicable, Early Entry refers to first access onto the floor, there is no sectioned off area.   If applicable, merchandise item/s will be available for pick-up the night of the show.   If applicable, laminate is commemorative only and does not gain or authorise access into the venue or backstage areas.   Any enquiries about your package can be directed to: mailto:info@vipnation.com.au",
                StartDate = DateTime.Parse("2022-09-15T09:30:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 919
            }, new VenueEvent
            {
                Id = 10111,
                Name = "KING OF ROCK & PRINCE OF POP",
                StartDate = DateTime.Parse("2022-08-20T10:00:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 919
            }, new VenueEvent
            {
                Id = 10112,
                Name = "Good Love Festival",
                StartDate = DateTime.Parse("2023-02-04T02:00:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 121
            }, new VenueEvent
            {
                Id = 10113,
                Name = "Michael Bisping",
                StartDate = DateTime.Parse("2022-11-25T08:30:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 125
            }, new VenueEvent
            {
                Id = 10114,
                Name = "I Prevail",
                StartDate = DateTime.Parse("2022-06-25T09:00:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 10029
            }, new VenueEvent
            {
                Id = 10115,
                Name = "I Prevail",
                StartDate = DateTime.Parse("2022-06-26T09:00:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 121
            }, new VenueEvent
            {
                Id = 10116,
                Name = "Elvis",
                StartDate = DateTime.Parse("2022-09-17T10:00:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 123
            }, new VenueEvent
            {
                Id = 10117,
                Name = "Elvis",
                StartDate = DateTime.Parse("2022-10-13T09:30:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 121
            }, new VenueEvent
            {
                Id = 10118,
                Name = "Wallows: Tell Me That It's Over Tour",
                StartDate = DateTime.Parse("2022-11-10T09:00:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 125
            }, new VenueEvent
            {
                Id = 10119,
                Name = "Chocolate Starfish",
                StartDate = DateTime.Parse("2023-04-14T12:00:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 121
            }, new VenueEvent
            {
                Id = 10120,
                Name = "Wallows: Tell Me That It's Over Tour",
                StartDate = DateTime.Parse("2022-11-08T08:15:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 919
            }, new VenueEvent
            {
                Id = 10121,
                Name = "Wallows: Tell Me That It's Over Tour",
                StartDate = DateTime.Parse("2022-11-10T09:00:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 123
            }, new VenueEvent
            {
                Id = 10122,
                Name = "SYNTHONY ",
                StartDate = DateTime.Parse("2022-11-19T06:00:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 919
            }, new VenueEvent
            {
                Id = 10123,
                Name = "Passenger",
                StartDate = DateTime.Parse("2022-10-07T11:30:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 919
            }, new VenueEvent
            {
                Id = 10124,
                Name = "The Australian Bee Gees Show",
                StartDate = DateTime.Parse("2022-08-13T10:00:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 919
            }, new VenueEvent
            {
                Id = 10125,
                Name = "Jay Chou ",
                Description = "Jay Chou, Asia’s Mandopop King is returning to Sydney with his 8th world concert tour on 4 March 2023 at Giants Stadium, Sydney Olympic Park. This is his first outdoor stadium concert in Australia. Jay is set to wow his fans with a brand-new theme “Carnival”.  With 14 albums, more than 150 songs and 7 sold out world tour concerts, the all new Jay Chou Carnival World Tour will be a celebration of his 20 years in the music business!",
                StartDate = DateTime.Parse("2023-03-04T09:00:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 123
            }, new VenueEvent
            {
                Id = 10126,
                Name = "Helmet",
                StartDate = DateTime.Parse("2022-12-31T11:00:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 10029
            }, new VenueEvent
            {
                Id = 10127,
                Name = "Helmet",
                StartDate = DateTime.Parse("2022-12-31T09:00:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 121
            }, new VenueEvent
            {
                Id = 10128,
                Name = "Helmet",
                StartDate = DateTime.Parse("2022-12-31T09:00:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 125
            }, new VenueEvent
            {
                Id = 10129,
                Name = "Bootleg Beatles",
                StartDate = DateTime.Parse("2022-11-04T09:00:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 121
            }, new VenueEvent
            {
                Id = 10130,
                Name = "Helmet",
                StartDate = DateTime.Parse("2022-12-31T09:00:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 125
            }, new VenueEvent
            {
                Id = 10131,
                Name = "Creative Generation - State Schools Onstage",
                StartDate = DateTime.Parse("2022-07-14T08:00:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 123
            }, new VenueEvent
            {
                Id = 10132,
                Name = "Creative Generation - State Schools Onstage",
                StartDate = DateTime.Parse("2022-07-15T09:00:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 919
            }, new VenueEvent
            {
                Id = 10133,
                Name = "Creative Generation - State Schools Onstage",
                StartDate = DateTime.Parse("2022-07-15T02:00:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 123
            }, new VenueEvent
            {
                Id = 10134,
                Name = "Creative Generation - State Schools Onstage",
                StartDate = DateTime.Parse("2022-07-16T04:00:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 125
            }, new VenueEvent
            {
                Id = 10135,
                Name = "Jimmy Barnes",
                StartDate = DateTime.Parse("2022-06-18T09:30:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 919
            }, new VenueEvent
            {
                Id = 10136,
                Name = "Gang of Youths",
                StartDate = DateTime.Parse("2022-08-20T01:00:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 121
            }, new VenueEvent
            {
                Id = 10137,
                Name = "Gang of Youths",
                StartDate = DateTime.Parse("2022-08-14T01:00:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 121
            }, new VenueEvent
            {
                Id = 10138,
                Name = "Joseph Calleja",
                StartDate = DateTime.Parse("2022-10-29T09:00:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 123
            }, new VenueEvent
            {
                Id = 10139,
                Name = "Joseph Calleja",
                StartDate = DateTime.Parse("2022-10-31T08:30:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 125
            }, new VenueEvent
            {
                Id = 10140,
                Name = "Leon Bridges",
                StartDate = DateTime.Parse("2022-09-29T10:00:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 123
            }, new VenueEvent
            {
                Id = 10141,
                Name = "Leon Bridges",
                StartDate = DateTime.Parse("2022-09-30T10:00:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 123
            }, new VenueEvent
            {
                Id = 10142,
                Name = "Jimmy Barnes",
                StartDate = DateTime.Parse("2022-06-16T09:05:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 121
            }, new VenueEvent
            {
                Id = 10143,
                Name = "Jimmy Barnes",
                StartDate = DateTime.Parse("2022-07-02T08:20:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 123
            }, new VenueEvent
            {
                Id = 10144,
                Name = "Leon Bridges",
                StartDate = DateTime.Parse("2022-09-27T09:30:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 10029
            }, new VenueEvent
            {
                Id = 10145,
                Name = "Jimmy Barnes",
                StartDate = DateTime.Parse("2022-06-24T08:20:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 121
            }, new VenueEvent
            {
                Id = 10146,
                Name = "Jimmy Barnes",
                StartDate = DateTime.Parse("2022-06-25T08:20:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 121
            }, new VenueEvent
            {
                Id = 10147,
                Name = "Atif Aslam",
                StartDate = DateTime.Parse("2022-09-04T11:00:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 125
            }, new VenueEvent
            {
                Id = 10148,
                Name = "Valleyways",
                StartDate = DateTime.Parse("2022-09-10T02:00:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 121
            }, new VenueEvent
            {
                Id = 10149,
                Name = "The Sapphires",
                StartDate = DateTime.Parse("2022-09-10T10:00:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 919
            }, new VenueEvent
            {
                Id = 10150,
                Name = "FANTASIA",
                StartDate = DateTime.Parse("2022-10-22T08:00:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 125
            }, new VenueEvent
            {
                Id = 10151,
                Name = "FANTASIA",
                StartDate = DateTime.Parse("2022-10-22T03:00:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 123
            }, new VenueEvent
            {
                Id = 10152,
                Name = "A Very Hiatus Halloween",
                StartDate = DateTime.Parse("2022-10-30T08:30:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 125
            }, new VenueEvent
            {
                Id = 10153,
                Name = "Postmodern Jukebox",
                StartDate = DateTime.Parse("2022-09-20T10:00:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 123
            }, new VenueEvent
            {
                Id = 10154,
                Name = "Michael Bublé",
                Description = "Multi-award-winning, multi-Platinum-selling global superstar Michael Bublé will make a welcome return to Australian stages this November and December.    During this 6-city national tour, the sensational Canadian entertainer will perform selections from his hotly anticipated 11th studio album, Higher, and a selection of his original smash hits alongside his trade-mark innovative takes on the great classics.    Michael Bublé's 6-city tour kicks off in Newcastle on Wednesday 30 November before touring to Perth, Melbourne, Adelaide, Sydney and Brisbane.    \"I have been touring Australia for 20 years now and the fact that you all keep turning up to my shows makes me feel like the luckiest man alive,\" Michael Bublé says. \"I absolutely adore performing live, being on stage is complete and utter enjoyment for me. It's a great pleasure and honour for me to be able to show up and be made feel so welcome.\"",
                StartDate = DateTime.Parse("2022-11-30T09:00:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 121
            }, new VenueEvent
            {
                Id = 10155,
                Name = "Postmodern Jukebox",
                StartDate = DateTime.Parse("2022-09-25T10:00:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 123
            }, new VenueEvent
            {
                Id = 10156,
                Name = "Harry Potter and the Half-Blood Prince™ ",
                StartDate = DateTime.Parse("2022-08-12T11:30:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 125
            }, new VenueEvent
            {
                Id = 10157,
                Name = "Harry Potter and the Half-Blood Prince™ ",
                StartDate = DateTime.Parse("2022-08-13T11:30:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 125
            }, new VenueEvent
            {
                Id = 10158,
                Name = "Postmodern Jukebox",
                StartDate = DateTime.Parse("2022-09-17T10:00:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 919
            }, new VenueEvent
            {
                Id = 10159,
                Name = "Michael Bublé",
                Description = "Multi-award-winning, multi-Platinum-selling global superstar Michael Bublé will make a welcome return to Australian stages this November and December.    During this 6-city national tour, the sensational Canadian entertainer will perform selections from his hotly anticipated 11th studio album, Higher, and a selection of his original smash hits alongside his trade-mark innovative takes on the great classics.    Michael Bublé's 6-city tour kicks off in Newcastle on Wednesday 30 November before touring to Perth, Melbourne, Adelaide, Sydney and Brisbane.    \"I have been touring Australia for 20 years now and the fact that you all keep turning up to my shows makes me feel like the luckiest man alive,\" Michael Bublé says. \"I absolutely adore performing live, being on stage is complete and utter enjoyment for me. It's a great pleasure and honour for me to be able to show up and be made feel so welcome.\"",
                StartDate = DateTime.Parse("2022-12-07T09:00:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 123
            }, new VenueEvent
            {
                Id = 10160,
                Name = "Michael Bublé",
                Description = "Multi-award-winning, multi-Platinum-selling global superstar Michael Bublé will make a welcome return to Australian stages this November and December.    During this 6-city national tour, the sensational Canadian entertainer will perform selections from his hotly anticipated 11th studio album, Higher, and a selection of his original smash hits alongside his trade-mark innovative takes on the great classics.    Michael Bublé's 6-city tour kicks off in Newcastle on Wednesday 30 November before touring to Perth, Melbourne, Adelaide, Sydney and Brisbane.    \"I have been touring Australia for 20 years now and the fact that you all keep turning up to my shows makes me feel like the luckiest man alive,\" Michael Bublé says. \"I absolutely adore performing live, being on stage is complete and utter enjoyment for me. It's a great pleasure and honour for me to be able to show up and be made feel so welcome.\"",
                StartDate = DateTime.Parse("2022-12-08T09:00:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 123
            }, new VenueEvent
            {
                Id = 10161,
                Name = "Postmodern Jukebox",
                StartDate = DateTime.Parse("2022-09-24T10:00:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 10029
            }, new VenueEvent
            {
                Id = 10162,
                Name = "Michael Bublé",
                Description = "Multi-award-winning, multi-Platinum-selling global superstar Michael Bublé will make a welcome return to Australian stages this November and December.    During this 6-city national tour, the sensational Canadian entertainer will perform selections from his hotly anticipated 11th studio album, Higher, and a selection of his original smash hits alongside his trade-mark innovative takes on the great classics.    Michael Bublé's 6-city tour kicks off in Newcastle on Wednesday 30 November before touring to Perth, Melbourne, Adelaide, Sydney and Brisbane.    \"I have been touring Australia for 20 years now and the fact that you all keep turning up to my shows makes me feel like the luckiest man alive,\" Michael Bublé says. \"I absolutely adore performing live, being on stage is complete and utter enjoyment for me. It's a great pleasure and honour for me to be able to show up and be made feel so welcome.\"",
                StartDate = DateTime.Parse("2022-12-14T09:00:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 919
            }, new VenueEvent
            {
                Id = 10163,
                Name = "Michael Bublé",
                Description = "Multi-award-winning, multi-Platinum-selling global superstar Michael Bublé will make a welcome return to Australian stages this November and December.    During this 6-city national tour, the sensational Canadian entertainer will perform selections from his hotly anticipated 11th studio album, Higher, and a selection of his original smash hits alongside his trade-mark innovative takes on the great classics.    Michael Bublé's 6-city tour kicks off in Newcastle on Wednesday 30 November before touring to Perth, Melbourne, Adelaide, Sydney and Brisbane.    \"I have been touring Australia for 20 years now and the fact that you all keep turning up to my shows makes me feel like the luckiest man alive,\" Michael Bublé says. \"I absolutely adore performing live, being on stage is complete and utter enjoyment for me. It's a great pleasure and honour for me to be able to show up and be made feel so welcome.\"",
                StartDate = DateTime.Parse("2022-12-03T12:00:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 123
            }, new VenueEvent
            {
                Id = 10164,
                Name = "Elvis by Request",
                StartDate = DateTime.Parse("2022-10-07T09:30:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 123
            }, new VenueEvent
            {
                Id = 10165,
                Name = "Elvis in Hollywood",
                StartDate = DateTime.Parse("2022-10-08T03:30:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 919
            }, new VenueEvent
            {
                Id = 10166,
                Name = "Elvis on Tour",
                StartDate = DateTime.Parse("2022-10-08T09:30:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 919
            }, new VenueEvent
            {
                Id = 10167,
                Name = "How Great Thou Art",
                StartDate = DateTime.Parse("2022-10-09T03:30:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 10029
            }, new VenueEvent
            {
                Id = 10168,
                Name = "56-77 The Greatest Performances",
                StartDate = DateTime.Parse("2022-10-09T09:15:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 123
            }, new VenueEvent
            {
                Id = 10169,
                Name = "Michael Bublé",
                Description = "Multi-award-winning, multi-Platinum-selling global superstar Michael Bublé will make a welcome return to Australian stages this November and December.    During this 6-city national tour, the sensational Canadian entertainer will perform selections from his hotly anticipated 11th studio album, Higher, and a selection of his original smash hits alongside his trade-mark innovative takes on the great classics.    Michael Bublé's 6-city tour kicks off in Newcastle on Wednesday 30 November before touring to Perth, Melbourne, Adelaide, Sydney and Brisbane.    \"I have been touring Australia for 20 years now and the fact that you all keep turning up to my shows makes me feel like the luckiest man alive,\" Michael Bublé says. \"I absolutely adore performing live, being on stage is complete and utter enjoyment for me. It's a great pleasure and honour for me to be able to show up and be made feel so welcome.\"",
                StartDate = DateTime.Parse("2022-12-11T09:30:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 10029
            }, new VenueEvent
            {
                Id = 10170,
                Name = "Postmodern Jukebox",
                StartDate = DateTime.Parse("2022-09-16T09:30:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 121
            }, new VenueEvent
            {
                Id = 10171,
                Name = "Foo Fighters",
                StartDate = DateTime.Parse("2022-12-12T08:00:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 121
            }, new VenueEvent
            {
                Id = 10172,
                Name = "Michael Bublé",
                Description = "Multi-award-winning, multi-Platinum-selling global superstar Michael Bublé will make a welcome return to Australian stages this November and December.    During this 6-city national tour, the sensational Canadian entertainer will perform selections from his hotly anticipated 11th studio album, Higher, and a selection of his original smash hits alongside his trade-mark innovative takes on the great classics.    Michael Bublé's 6-city tour kicks off in Newcastle on Wednesday 30 November before touring to Perth, Melbourne, Adelaide, Sydney and Brisbane.    \"I have been touring Australia for 20 years now and the fact that you all keep turning up to my shows makes me feel like the luckiest man alive,\" Michael Bublé says. \"I absolutely adore performing live, being on stage is complete and utter enjoyment for me. It's a great pleasure and honour for me to be able to show up and be made feel so welcome.\"",
                StartDate = DateTime.Parse("2022-12-17T10:00:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 919
            }, new VenueEvent
            {
                Id = 10173,
                Name = "Michael Bublé",
                Description = "Multi-award-winning, multi-Platinum-selling global superstar Michael Bublé will make a welcome return to Australian stages this November and December.    During this 6-city national tour, the sensational Canadian entertainer will perform selections from his hotly anticipated 11th studio album, Higher, and a selection of his original smash hits alongside his trade-mark innovative takes on the great classics.    Michael Bublé's 6-city tour kicks off in Newcastle on Wednesday 30 November before touring to Perth, Melbourne, Adelaide, Sydney and Brisbane.    \"I have been touring Australia for 20 years now and the fact that you all keep turning up to my shows makes me feel like the luckiest man alive,\" Michael Bublé says. \"I absolutely adore performing live, being on stage is complete and utter enjoyment for me. It's a great pleasure and honour for me to be able to show up and be made feel so welcome.\"",
                StartDate = DateTime.Parse("2022-12-18T10:00:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 125
            }, new VenueEvent
            {
                Id = 10174,
                Name = "Postmodern Jukebox",
                StartDate = DateTime.Parse("2022-09-23T10:00:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 123
            }, new VenueEvent
            {
                Id = 10175,
                Name = "Postmodern Jukebox",
                StartDate = DateTime.Parse("2022-09-29T10:00:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 125
            }, new VenueEvent
            {
                Id = 10176,
                Name = "Keith Urban",
                Description = "Five-time ARIA and four-time GRAMMY Award winner Keith Urban returns to Australia for his ‘THE SPEED OF NOW WORLD TOUR 2022’, presented by Youi. It marks Urban’s first concerts in Australia in more than two years and will be the first chance that fans will have to see him perform songs from his #1 tenth studio album.    Urban is always pushing forward with insatiable creative hunger. During ‘THE SPEED OF NOW WORLD TOUR 2022’ Urban will deliver a set filled with his best-known hits including ‘One Too Many’, ‘The Fighter’, ‘Wasted Time’, ‘Blue Ain’t Your Colour’, ‘Long Hot Summer’, and songs from his #1 album, THE SPEED OF NOW Part 1’ and never-before-seen state of the art production.    Urban’s two-hour plus shows are power packed with an energy and showmanship that gives him the unique ability to touch every soul in the audience from the first note to the final confetti drop and consistently reaffirms his reputation as one of the music industry’s best live performers, and with the addition of Birds of Tokyo, ‘THE SPEED OF NOW WORLD TOUR 2022’ is shaping up to be one of the year’s most anticipated tours.",
                StartDate = DateTime.Parse("2022-12-10T05:30:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 919
            }, new VenueEvent
            {
                Id = 10177,
                Name = "Keith Urban",
                Description = "Five-time ARIA and four-time GRAMMY Award winner Keith Urban returns to Australia for his ‘THE SPEED OF NOW WORLD TOUR 2022’, presented by Youi. It marks Urban’s first concerts in Australia in more than two years and will be the first chance that fans will have to see him perform songs from his #1 tenth studio album.    Urban is always pushing forward with insatiable creative hunger. During ‘THE SPEED OF NOW WORLD TOUR 2022’ Urban will deliver a set filled with his best-known hits including ‘One Too Many’, ‘The Fighter’, ‘Wasted Time’, ‘Blue Ain’t Your Colour’, ‘Long Hot Summer’, and songs from his #1 album, THE SPEED OF NOW Part 1’ and never-before-seen state of the art production.    Urban’s two-hour plus shows are power packed with an energy and showmanship that gives him the unique ability to touch every soul in the audience from the first note to the final confetti drop and consistently reaffirms his reputation as one of the music industry’s best live performers, and with the addition of Birds of Tokyo, ‘THE SPEED OF NOW WORLD TOUR 2022’ is shaping up to be one of the year’s most anticipated tours.",
                StartDate = DateTime.Parse("2022-12-12T08:00:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 121
            }, new VenueEvent
            {
                Id = 10178,
                Name = "Keith Urban",
                Description = "Five-time ARIA and four-time GRAMMY Award winner Keith Urban returns to Australia for his ‘THE SPEED OF NOW WORLD TOUR 2022’, presented by Youi. It marks Urban’s first concerts in Australia in more than two years and will be the first chance that fans will have to see him perform songs from his #1 tenth studio album.    Urban is always pushing forward with insatiable creative hunger. During ‘THE SPEED OF NOW WORLD TOUR 2022’ Urban will deliver a set filled with his best-known hits including ‘One Too Many’, ‘The Fighter’, ‘Wasted Time’, ‘Blue Ain’t Your Colour’, ‘Long Hot Summer’, and songs from his #1 album, THE SPEED OF NOW Part 1’ and never-before-seen state of the art production.    Urban’s two-hour plus shows are power packed with an energy and showmanship that gives him the unique ability to touch every soul in the audience from the first note to the final confetti drop and consistently reaffirms his reputation as one of the music industry’s best live performers, and with the addition of Birds of Tokyo, ‘THE SPEED OF NOW WORLD TOUR 2022’ is shaping up to be one of the year’s most anticipated tours.",
                StartDate = DateTime.Parse("2022-12-16T08:00:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 919
            }, new VenueEvent
            {
                Id = 10179,
                Name = "Keith Urban",
                Description = "Five-time ARIA and four-time GRAMMY Award winner Keith Urban returns to Australia for his ‘THE SPEED OF NOW WORLD TOUR 2022’, presented by Youi. It marks Urban’s first concerts in Australia in more than two years and will be the first chance that fans will have to see him perform songs from his #1 tenth studio album.    Urban is always pushing forward with insatiable creative hunger. During ‘THE SPEED OF NOW WORLD TOUR 2022’ Urban will deliver a set filled with his best-known hits including ‘One Too Many’, ‘The Fighter’, ‘Wasted Time’, ‘Blue Ain’t Your Colour’, ‘Long Hot Summer’, and songs from his #1 album, THE SPEED OF NOW Part 1’ and never-before-seen state of the art production.    Urban’s two-hour plus shows are power packed with an energy and showmanship that gives him the unique ability to touch every soul in the audience from the first note to the final confetti drop and consistently reaffirms his reputation as one of the music industry’s best live performers, and with the addition of Birds of Tokyo, ‘THE SPEED OF NOW WORLD TOUR 2022’ is shaping up to be one of the year’s most anticipated tours.",
                StartDate = DateTime.Parse("2022-12-17T08:00:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 121
            }, new VenueEvent
            {
                Id = 10180,
                Name = "Keith Urban",
                Description = "Five-time ARIA and four-time GRAMMY Award winner Keith Urban returns to Australia for his ‘THE SPEED OF NOW WORLD TOUR 2022’, presented by Youi. It marks Urban’s first concerts in Australia in more than two years and will be the first chance that fans will have to see him perform songs from his #1 tenth studio album.    Urban is always pushing forward with insatiable creative hunger. During ‘THE SPEED OF NOW WORLD TOUR 2022’ Urban will deliver a set filled with his best-known hits including ‘One Too Many’, ‘The Fighter’, ‘Wasted Time’, ‘Blue Ain’t Your Colour’, ‘Long Hot Summer’, and songs from his #1 album, THE SPEED OF NOW Part 1’ and never-before-seen state of the art production.    Urban’s two-hour plus shows are power packed with an energy and showmanship that gives him the unique ability to touch every soul in the audience from the first note to the final confetti drop and consistently reaffirms his reputation as one of the music industry’s best live performers, and with the addition of Birds of Tokyo, ‘THE SPEED OF NOW WORLD TOUR 2022’ is shaping up to be one of the year’s most anticipated tours.",
                StartDate = DateTime.Parse("2022-12-05T08:00:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 125
            }, new VenueEvent
            {
                Id = 10181,
                Name = "Keith Urban",
                Description = "Five-time ARIA and four-time GRAMMY Award winner Keith Urban returns to Australia for his ‘THE SPEED OF NOW WORLD TOUR 2022’, presented by Youi. It marks Urban’s first concerts in Australia in more than two years and will be the first chance that fans will have to see him perform songs from his #1 tenth studio album.    Urban is always pushing forward with insatiable creative hunger. During ‘THE SPEED OF NOW WORLD TOUR 2022’ Urban will deliver a set filled with his best-known hits including ‘One Too Many’, ‘The Fighter’, ‘Wasted Time’, ‘Blue Ain’t Your Colour’, ‘Long Hot Summer’, and songs from his #1 album, THE SPEED OF NOW Part 1’ and never-before-seen state of the art production.    Urban’s two-hour plus shows are power packed with an energy and showmanship that gives him the unique ability to touch every soul in the audience from the first note to the final confetti drop and consistently reaffirms his reputation as one of the music industry’s best live performers, and with the addition of Birds of Tokyo, ‘THE SPEED OF NOW WORLD TOUR 2022’ is shaping up to be one of the year’s most anticipated tours.",
                StartDate = DateTime.Parse("2022-12-06T08:00:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 10029
            }, new VenueEvent
            {
                Id = 10182,
                Name = "Keith Urban",
                Description = "Five-time ARIA and four-time GRAMMY Award winner Keith Urban returns to Australia for his ‘THE SPEED OF NOW WORLD TOUR 2022’, presented by Youi. It marks Urban’s first concerts in Australia in more than two years and will be the first chance that fans will have to see him perform songs from his #1 tenth studio album.    Urban is always pushing forward with insatiable creative hunger. During ‘THE SPEED OF NOW WORLD TOUR 2022’ Urban will deliver a set filled with his best-known hits including ‘One Too Many’, ‘The Fighter’, ‘Wasted Time’, ‘Blue Ain’t Your Colour’, ‘Long Hot Summer’, and songs from his #1 album, THE SPEED OF NOW Part 1’ and never-before-seen state of the art production.    Urban’s two-hour plus shows are power packed with an energy and showmanship that gives him the unique ability to touch every soul in the audience from the first note to the final confetti drop and consistently reaffirms his reputation as one of the music industry’s best live performers, and with the addition of Birds of Tokyo, ‘THE SPEED OF NOW WORLD TOUR 2022’ is shaping up to be one of the year’s most anticipated tours.",
                StartDate = DateTime.Parse("2022-12-14T08:30:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 121
            }, new VenueEvent
            {
                Id = 10183,
                Name = "Keith Urban",
                Description = "Five-time ARIA and four-time GRAMMY Award winner Keith Urban returns to Australia for his ‘THE SPEED OF NOW WORLD TOUR 2022’, presented by Youi. It marks Urban’s first concerts in Australia in more than two years and will be the first chance that fans will have to see him perform songs from his #1 tenth studio album.    Urban is always pushing forward with insatiable creative hunger. During ‘THE SPEED OF NOW WORLD TOUR 2022’ Urban will deliver a set filled with his best-known hits including ‘One Too Many’, ‘The Fighter’, ‘Wasted Time’, ‘Blue Ain’t Your Colour’, ‘Long Hot Summer’, and songs from his #1 album, THE SPEED OF NOW Part 1’ and never-before-seen state of the art production.    Urban’s two-hour plus shows are power packed with an energy and showmanship that gives him the unique ability to touch every soul in the audience from the first note to the final confetti drop and consistently reaffirms his reputation as one of the music industry’s best live performers, and with the addition of Birds of Tokyo, ‘THE SPEED OF NOW WORLD TOUR 2022’ is shaping up to be one of the year’s most anticipated tours.",
                StartDate = DateTime.Parse("2022-12-02T09:00:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 125
            }, new VenueEvent
            {
                Id = 10184,
                Name = "Keith Urban",
                Description = "Five-time ARIA and four-time GRAMMY Award winner Keith Urban returns to Australia for his ‘THE SPEED OF NOW WORLD TOUR 2022’, presented by Youi. It marks Urban’s first concerts in Australia in more than two years and will be the first chance that fans will have to see him perform songs from his #1 tenth studio album.    Urban is always pushing forward with insatiable creative hunger. During ‘THE SPEED OF NOW WORLD TOUR 2022’ Urban will deliver a set filled with his best-known hits including ‘One Too Many’, ‘The Fighter’, ‘Wasted Time’, ‘Blue Ain’t Your Colour’, ‘Long Hot Summer’, and songs from his #1 album, THE SPEED OF NOW Part 1’ and never-before-seen state of the art production.    Urban’s two-hour plus shows are power packed with an energy and showmanship that gives him the unique ability to touch every soul in the audience from the first note to the final confetti drop and consistently reaffirms his reputation as one of the music industry’s best live performers, and with the addition of Birds of Tokyo, ‘THE SPEED OF NOW WORLD TOUR 2022’ is shaping up to be one of the year’s most anticipated tours.",
                StartDate = DateTime.Parse("2022-12-03T09:00:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 10029
            }, new VenueEvent
            {
                Id = 10185,
                Name = "Keith Urban",
                Description = "Five-time ARIA and four-time GRAMMY Award winner Keith Urban returns to Australia for his ‘THE SPEED OF NOW WORLD TOUR 2022’, presented by Youi. It marks Urban’s first concerts in Australia in more than two years and will be the first chance that fans will have to see him perform songs from his #1 tenth studio album.    Urban is always pushing forward with insatiable creative hunger. During ‘THE SPEED OF NOW WORLD TOUR 2022’ Urban will deliver a set filled with his best-known hits including ‘One Too Many’, ‘The Fighter’, ‘Wasted Time’, ‘Blue Ain’t Your Colour’, ‘Long Hot Summer’, and songs from his #1 album, THE SPEED OF NOW Part 1’ and never-before-seen state of the art production.    Urban’s two-hour plus shows are power packed with an energy and showmanship that gives him the unique ability to touch every soul in the audience from the first note to the final confetti drop and consistently reaffirms his reputation as one of the music industry’s best live performers, and with the addition of Birds of Tokyo, ‘THE SPEED OF NOW WORLD TOUR 2022’ is shaping up to be one of the year’s most anticipated tours.",
                StartDate = DateTime.Parse("2022-12-01T09:00:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 123
            }, new VenueEvent
            {
                Id = 10186,
                Name = "CHARLIE AND THE CHOCOLATE FACTORY",
                StartDate = DateTime.Parse("2022-06-24T09:30:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 10029
            }, new VenueEvent
            {
                Id = 10187,
                Name = "CHARLIE AND THE CHOCOLATE FACTORY",
                StartDate = DateTime.Parse("2022-06-25T09:30:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 121
            }, new VenueEvent
            {
                Id = 10188,
                Name = "CHARLIE AND THE CHOCOLATE FACTORY",
                StartDate = DateTime.Parse("2022-06-25T03:30:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 10029
            }, new VenueEvent
            {
                Id = 10189,
                Name = "CHARLIE AND THE CHOCOLATE FACTORY",
                StartDate = DateTime.Parse("2022-06-26T03:30:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 10029
            }, new VenueEvent
            {
                Id = 10190,
                Name = "CHARLIE AND THE CHOCOLATE FACTORY",
                StartDate = DateTime.Parse("2022-06-30T09:30:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 10029
            }, new VenueEvent
            {
                Id = 10191,
                Name = "CHARLIE AND THE CHOCOLATE FACTORY",
                StartDate = DateTime.Parse("2022-07-01T09:30:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 919
            }, new VenueEvent
            {
                Id = 10192,
                Name = "CHARLIE AND THE CHOCOLATE FACTORY",
                StartDate = DateTime.Parse("2022-07-02T09:30:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 121
            }, new VenueEvent
            {
                Id = 10193,
                Name = "CHARLIE AND THE CHOCOLATE FACTORY",
                StartDate = DateTime.Parse("2022-07-02T03:30:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 125
            }, new VenueEvent
            {
                Id = 10194,
                Name = "CHARLIE AND THE CHOCOLATE FACTORY",
                StartDate = DateTime.Parse("2022-07-03T03:30:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 125
            }, new VenueEvent
            {
                Id = 10195,
                Name = "CHARLIE AND THE CHOCOLATE FACTORY",
                StartDate = DateTime.Parse("2022-07-07T09:30:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 123
            }, new VenueEvent
            {
                Id = 10196,
                Name = "CHARLIE AND THE CHOCOLATE FACTORY",
                StartDate = DateTime.Parse("2022-07-08T09:30:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 10029
            }, new VenueEvent
            {
                Id = 10197,
                Name = "CHARLIE AND THE CHOCOLATE FACTORY",
                StartDate = DateTime.Parse("2022-07-09T09:30:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 10029
            }, new VenueEvent
            {
                Id = 10198,
                Name = "CHARLIE AND THE CHOCOLATE FACTORY",
                StartDate = DateTime.Parse("2022-07-09T03:30:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 10029
            }, new VenueEvent
            {
                Id = 10199,
                Name = "Popstars",
                StartDate = DateTime.Parse("2022-06-14T08:30:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 10029
            }, new VenueEvent
            {
                Id = 312,
                Name = "High Expectations Touring Australia 2022!",
                StartDate = DateTime.Parse("2023-06-12T02:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                VenueId = 123
            }, new VenueEvent
            {
                Id = 122,
                Name = "TegTalk",
                StartDate = DateTime.Parse("2023-06-10T10:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                Description = "A much anticipated talk on all things TEG.",
                VenueId = 125
            }, new VenueEvent
            {
                Id = 1002,
                Name = "Learn to Code! 101",
                StartDate = DateTime.Parse("2023-06-11T09:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                Description = "A basic workshop for going from zero to hero as a coder!",
                VenueId = 125
            }, new VenueEvent
            {
                Id = 192,
                Name = "Master the Art of Coding Challenges",
                StartDate = DateTime.Parse("2023-07-23T08:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                Description = "The be all end all seminar on smashing every coding challenge thrown at you!",
                VenueId = 125
            }, new VenueEvent
            {
                Id = 998,
                Name = "A night at the TEG Technology Museum",
                StartDate = DateTime.Parse("2023-06-03T14:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                Description = "An immersive overnight experience showcasing TEG's rich history of technology dating back all the way to the 1970s!",
                VenueId = 10029
            }, new VenueEvent
            {
                Id = 500,
                Name = "Coding Lab: handling errors with grace.",
                StartDate = DateTime.Parse("2023-06-15T09:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                Description = "A coding lab hosted by one of our very own Tech Leads showcasing best practices for handling errors gracefully.",
                VenueId = 404
            }, new VenueEvent
            {
                Id = 81,
                Name = "Futurology of Ticketing",
                StartDate = DateTime.Parse("2023-06-22T10:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                Description = "An interactive seminar on the latest trends and future expectations surrounding the world of ticketing.",
                VenueId = 919
            }, new VenueEvent
            {
                Id = 922,
                Name = "Inversion of Control",
                Description = "Lost control of all your senses with this year's immersive light show Inversion of Control!",
                StartDate = DateTime.Parse("2023-06-01T10:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 919
            }, new VenueEvent
            {
                Id = 923,
                Name = "Dreaming of Electric Sheep",
                Description = "A late night experience for the Androids in our world.",
                StartDate = DateTime.Parse("2023-06-03T09:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                VenueId = 919
            });
        dbContext.SaveChanges();
    }
}