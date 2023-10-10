﻿using Microsoft.EntityFrameworkCore;
using Shopping_Cart.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<MyDbContext>(options => {
    var conn_str = builder.Configuration.GetConnectionString("conn_string");
    options.UseLazyLoadingProxies().UseSqlServer(conn_str);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Gallery}/{action=Index}/{id?}");

InitDB(app.Services);

app.Run();

void InitDB(IServiceProvider serviceProvider)
{
    using var scope = serviceProvider.CreateScope();
    MyDbContext db = scope.ServiceProvider.GetRequiredService<MyDbContext>();
    
    db.Database.EnsureDeleted();
    db.Database.EnsureCreated();
    db.Add(new User { UserId = "Lushuwen", Password = "Lushuwen" });
    db.Add(new User { UserId = "Huxinxing", Password = "Huxinxing" });
    db.Add(new User { UserId = "Wangyibing", Password = "Wangyibing" });
    db.Add(new User { UserId = "Songborui", Password = "Songborui" });

    db.Add(new Product { Id = "001", Description = "Oscar Wilde, the great English wordsmith after Shakespeare.\r\n\"The Happy Prince,\" \"The Nightingale and the Rose,\" \"The Selfish Giant\" is not only a classic of English literature, but also a classic of world literature.\r\nHe introduced the concept of adult fairy tales and declared that his fairy tales were written for adults. His fairy tales are famous around the world for their beautiful love and kindness.\r\nThis book contains all nine of Wilde's fairy tales, \"The Happy Prince\", \"The Nightingale and the Rose\", \"The Selfish Giant\", \"The Faithful Friend\", \"The Great Rocket\", \"The Young King\", \"The Birthday of the Spanish Princess\", \"The Fisherman and His Soul\" and \"The Star Child\". In addition, six rare pieces of Wilde's prose poems \"The Artist\", \"The Do-gooder\", \"The Disciple\", \"The Teacher\", \"The Judgment House\" and \"The Classroom of Wisdom\" are also included.\r\nTranslator Tan Yingzhou is a professor of foreign languages at Fudan University, director of the Institute of Foreign Literature, and an expert in the study of Oscar Wilde and aestheticism. He brings an accurate and in-depth translation of the style and the author's thoughts to this book.\r\nWilde describes the beauty and sorrow in life -- the love in ordinary life, the beauty in the spiritual world, and the great pain brought by the destruction of these two to the human soul, highlighting the salvation and destination of the divine. Wilde no longer repeats the cliche that the prince and princess lived happily for a hundred years, nor does he express the good wish that good will be rewarded with evil, but only tells the tragedy in a tone of indifference, and makes the reader hear the fisherman's long sigh, the nightingale's song like a gosser after the end of the life, the dwarf's mournful cry and the sound of his heart breaking through the eyes of the characters. He repeatedly asks about the contradictions and paradoxes everywhere in life with fairy tales, alludes to the difficulties and complexities of the real society, and shows his pure pursuit of art, love and life in a tortuous way.", Evaluation = 0, Name = "The Nightingale and the Rose", Price = 23.5 });
    db.Add(new Product { Id = "002", Description = "Flipped directed by Rob Reiner. The film revolves around a boy named Bryce and his classmate Julie. From the perspective of a teenager, the film shows all aspects of their love, such as vague ambiguity, unrequited love, brave pursuit, and so on, which has touched many audiences.\r\nSome of us get dipped in flat,some in satin,some in gloss.But every once in a while,you find someone who's iridescent,and when you do,nothing will ever compare.", Evaluation = 0, Name = "Flipped", Price = 25.8 });
    db.Add(new Product { Id = "003", Description = "Walden is a collection of essays by American writer Henry David Thoreau. In the book, the author describes in detail the two years and two months he spent in the woods of Walden Pond and the many thoughts he had during that time. He described the experience as an attempt at a simple, secluded life. Based on his transcendentalist viewpoint, the author gives a wonderful description of the seasonal change and spiritual recovery in nature. In the book, the author talks about the past and the present, praises the natural beauty and denounces the social evils. The subtlety of its writing and the depth of its analysis have amazed generations of readers.", Evaluation = 0, Name = "Walden", Price = 12.74 });
    db.Add(new Product { Id = "004", Description = "It is said that this book is known as the second Bible for women, and the depiction of women's independence, perseverance, bravery and rationality in the book has moistened the hearts of many women and given them the strength to face life and love.\r\nAlthough the author says that the book is not autobiographical, it bears some resemblance to the author's own experience. Sure enough, good fiction works are derived from people's real life experiences. Only the truth, is the most charming.\r\nThe book can be roughly divided into five parts: the first part is the heroine Jane Eyre's childhood situation in her uncle's house (Gateshead Hall); The second part is Jane Eyre's experience in Lowood boarding School; The third part is Jane Eyre's experience as a governess in Mr. Rochester's home (Thornfield Hall); The fourth part is the time spent at Moor House, away from Thornfield Hall; And finally, with Mr. Rochester at Ferndean Park.", Evaluation = 0, Name = "Jane Eyre", Price = 29.4 });
    db.Add(new Product { Id = "005", Description = "\"Alive\" in the third person tells the story of a rural old man Fugui through the vicissitudes of life and suffering, from the young rich squandered, to lose all the family property, his father died, was captured, came back to the mother died, his daughter became deaf mute, his son gave blood to people died. His wife died because of illness and his daughter died after giving birth to a child, and his son-in-law died in an accident at work. Left a grandson, because the family was poor, there was nothing to eat, the old man cooked fresh beans for the grandson, went out to do things, the child because of hunger, eat too much, bloated to death. Look at these experiences, how can not make people cry, life is full of hardships, blows one after another. That leaves him with a cow named Fugui. The book tells us that people live for the sake of living itself, not for anything outside of living. The resilience and breadth of life in the face of suffering. The film of the same name won the Grand Jury Prize of the Cannes Film Festival and the must-read classic of Chinese literature. The Berliner Zeitung once praised the book's value beyond any critical word, and the word \"great\" seemed small before it. In the face of life, this is a book worth your quiet mind to read, telling you that in the face of suffering setbacks, people's hearts beyond.", Evaluation = 0, Name = "Alive", Price = 10.5 });
    db.Add(new Product { Id = "006", Description = "From the author of Dear Edward comes a \"powerfully affecting\" (People) family story that asks: Can love make a broken person whole?\r\n\"Another tender tearjerker . . . Napolitano chronicles life’s highs and lows with aching precision.\"—The Washington Post\r\nWilliam Waters grew up in a house silenced by tragedy, where his parents could hardly bear to look at him, much less love him—so when he meets the spirited and ambitious Julia Padavano in his freshman year of college, it’s as if the world has lit up around him.\r\nWith Julia comes her family, as she and her three sisters are inseparable: Sylvie, the family’s dreamer, is happiest with her nose in a book; Cecelia is a free-spirited artist; and Emeline patiently takes care of them all.", Evaluation = 0, Name = "Hello Beautiful", Price = 13.99 });
    db.Add(new Product { Id = "007", Description = "“Remarkably Bright Creatures is a beautiful examination of how loneliness can be transformed, cracked open, with the slightest touch from another living thing.\" -- Kevin Wilson, author of Nothing to See Here\r\nFor fans of A Man Called Ove, a charming, witty and compulsively readable exploration of friendship, reckoning, and hope that traces a widow's unlikely connection with a giant Pacific octopus\r\nAfter Tova Sullivan’s husband died, she began working the night shift at the Sowell Bay Aquarium, mopping floors and tidying up. Keeping busy has always helped her cope, which she’s been doing since her eighteen-year-old son, Erik, mysteriously vanished on a boat in Puget Sound over thirty years ago.\r\n", Evaluation = 0, Name = "Remarkably Bright Creatures", Price = 15.71 });
    db.Add(new Product { Id = "008", Description = "\"Sexy, messy and wry, Honey and Spice more than delivers.\" — New York Times Book Review\r\n\"A vibrant debut novel . . . Babalola is incisively funny, capturing the kick and sweetness of her title with her words.\" — Entertainment Weekly\r\nNamed a Best Book of the Year by Time • Esquire • Vanity Fair • Oprah Daily • Cosmopolitan • Elle • Harper's Bazaar • Southern Living • Buzzfeed • Women's Health Magazine • AudioFile • Popsugar • and more!\r\n", Evaluation = 0, Name = "Honey and Spice", Price = 11.99 });
    db.Add(new Product { Id = "009", Description = "It is a truth universally acknowledged, that a single man in possession of a good fortune, must be in want of a wife.\"\r\nSince its immediate success in 1813, Pride and Prejudice has remained one of the most popular novels in the English language.\r\nJane Austen called this brilliant work \"her own darling child\" and its vivacious heroine, Elizabeth Bennet, \"as delightful a creature as ever appeared in print.\" The romantic clash between the opinionated Elizabeth and her proud beau, Mr Darcy, is a splendid performance of civilized sparring, and Jane Austen's radiant wit sparkles as her characters dance a delicate quadrille of flirtation and intrigue, making this book the most superb comedy of manners of Regency England.", Evaluation = 0, Name = "Pride and Prejudice", Price = 15.31 });
    db.Add(new Product { Id = "010", Description = "Set your Mediterranean table for two with perfectly portioned dishes\r\nWith crisp veggies, succulent seafood, hearty grains, and healthy oils, the Mediterranean diet makes nutritious eating a pleasure. This cookbook brings its bright flavors and bountiful health benefits to your table with recipes designed for two people.\r\nRelax and savor a delicious breezy seaside breakfast or a simple rustic dinner, all without leaving home. Together, discover how a Mediterranean lifestyle can reduce the risk of heart disease, aid in weight loss, and more.\r\n", Evaluation = 0, Name = "The Mediterranean Diet Cookbook for Two", Price = 15.99 });
    db.Add(new Product { Id = "011", Description = "The novel tells the tragic story of the carpenter's son, Julien, who was unable to be with the Marquis because of his humble position, and was finally sentenced to death because of the jealousy of the hostile class. The book widely shows \"the social atmosphere brought by successive governments that weighed on the French people in the early 30 years of the 19th century\", and strongly criticizes the reactionary aristocracy during the Restoration Dynasty, the darkness of the church and the meanness and vulgarity of bourgeois new noble.", Evaluation = 0, Name = "The Red And Black", Price = 15.55 });
    db.Add(new Product { Id = "012", Description = "Hamlet, a tragic work written by william shakespeare in 1602, is one of the world famous tragedies.\r\nHamlet reflects the social reality of Britain in the late 16th and early 17th centuries through the history of Denmark in the 8th century. It has profound tragic significance, complex characters and rich and perfect tragic artistic techniques, and represents the highest achievement of the whole Western Renaissance literature.", Evaluation = 0, Name = "Hamlet", Price = 12.69 });
    db.Add(new Product { Id = "013", Description = "The hero K was hired to be a land surveyor in the castle. After a long journey through many Snowy Road, he finally arrived at a poor village under the jurisdiction of the castle in the middle of the night. In the village guest house, exhausted K met all kinds of people, all of whom were civilians struggling at the bottom of society. Among them are the boss, proprietress, waitress and some other people. Although the castle is close at hand, he went to great pains to seduce the mistress of the castle official Cramer, but he couldn't get in. K was exhausted from running around, but he couldn't enter the castle until he died.", Evaluation = 0, Name = "The Castle", Price = 19.99 });
    db.Add(new Product { Id = "014", Description = "The Gadfly is a novel published by China Youth Publishing House in July 1953. It was first published in 1897 by an Irish woman writer Voynich.\r\nThe book describes the life of the Italian revolutionary gadfly, who participated in the struggle against the Austrian rulers and for national independence and reunification, and finally gave his life for it. The novel involves such colorful themes as struggle, belief and sacrifice.", Evaluation = 0, Name = "The Gadfly", Price = 14.89 });
    db.Add(new Product { Id = "015", Description = "Gulliver's Travels is an anonymous long travelogue satirical novel written by British writer jonathan swift under a pseudonym.\r\nUnder the guise of fictional characters, the author describes a series of magical travel experiences with rich satire and fictional fantasy, which reflects the partisan struggle in the British Parliament at that time, the fatuity and decay of the ruling group, and the cruelty and violence of the colonial war. At the same time, it praises the heroic struggle of the colonial people against the rulers.", Evaluation = 0, Name = "Gulliver's Travels", Price = 19.99 });
    db.Add(new Product { Id = "016", Description = "This book comprehensively introduces the LTE communication network architecture, signaling process and product operation and maintenance. The book has a total of 10 chapters, which describe the wireless communication theory, LTE key technology, LTE air interface, LTE signaling process, EPC network principle, LTE base station principle and operation and maintenance, LTE network planning and optimization, LTE simulation system and 5G technology evolution, etc. The whole book is implanted with a QR code. The way is interspersed with many online videos to help readers consolidate what they have learned.", Evaluation = 0, Name = "Mobile communication technology", Price = 12.98});
    db.Add(new Product { Id = "017", Description = "Signals and Systems (3rd Edition) It discusses the basic concepts and basic analysis methods of deterministic signal transmission and processing through linear time-invariant systems, from time domain to transformation domain, from continuous to discrete, from input and output description to state space description, with communication and control engineering as the main Application background, focusing on case analysis. The third edition maintains the characteristics of the first two editions: focusing on combining basic theories and integrating various engineering application examples. The new edition has revised and updated these examples to give the whole book a strong sense of the times; it retains the content of the sixth chapter of signal vector spatial analysis, and has appropriate revisions and supplements, so as to highlight the important difference between Signals and Systems (3rd edition) (Volume I) and similar textbooks at home and abroad; the structure of the whole book is more flexible. It can be applied to the teaching of undergraduates in a variety of science and engineering majors in communication electronics and non-communication electronics.", Evaluation = 0, Name = "Signals and Systems", Price = 15.56});
    db.Add(new Product { Id = "018", Description = "There are 10 chapters in the book (excluding the introduction part), namely, time-domain discrete signals and time-domain discrete systems, time-domain discrete signals and system frequency domain analysis, discrete Fourier transform (DFT), fast Fourier transform (FFT), network structure of time-domain discrete systems, and the design of infinite pulse response digital filters, Design of finite impulse response digital filter, multi-sampling rate digital signal processing, implementation of digital signal processing, computer experiment (including five basic theoretical experiments and a comprehensive application experiment).", Evaluation = 0, Name = "Digital Signal Processing", Price = 21.29});
    db.Add(new Product { Id = "019", Description = "Java language has excellent features such as object-oriented, platform-independent, safe, stable and multi-threading. It is an extremely powerful programming language in software design at present. The book focuses on combining examples and important design patterns to introduce the important knowledge of Java object-oriented programming to readers step by step. For more difficult to understand problems, the examples are all from simple to complex, which is convenient for readers to master the idea of Java object-oriented programming. The book is divided into 17 chapters, explaining basic data types, arrays and enumeration types, operators, expressions and statements, classes and objects, inheritance and interfaces, internal classes, anonymous classes and Lambda expressions, exception classes, basic principles of object-oriented design, design patterns, common practical classes, JavaSw Ing, dialog box, input stream and output stream, generic and collection framework, JDBC and MySQL database, Java multithreading mechanism, Java network foundation, and a word dictionary instance based on embedded database.", Evaluation = 0, Name = "Java object-oriented programming", Price = 21.59});
    db.Add(new Product { Id = "020", Description = "PLC Programming from Zero Foundation to Practice: Illustrated Video Case is guided by the national professional qualification standards, combined with industry training specifications, and relies on typical cases to comprehensively and meticulously introduce PLC programming basics, programming languages, programming methods, touch screens, PLC control applications and other professional knowledge and skills.It includes: the basics of electrical control circuits, the types and functional characteristics of PLC, the relationship between electrical components and electrical control, the composition and working principle of PLC, the programming mode and programming software of PLC, Siemens PLC ladder diagram, Siemens PLC statement table, Siemens PLC programming, Mitsubishi PLC ladder diagram, Sanling PLC statement table, Mitsubishi PLC programming, PLC touch screen, PLC programming application cases, etc.", Evaluation = 0, Name = "PLC Programming from Zero", Price = 16.66});


    db.SaveChanges();
}