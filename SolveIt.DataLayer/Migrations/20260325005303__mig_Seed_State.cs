using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SolveIt.DataLayer.Migrations
{
	/// <inheritdoc />
	public partial class _mig_Seed_State : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.InsertData(
				table: "States",
				columns: new[] { "Id", "CreatedDate", "CreatedUserId", "Description", "Guid", "IsActive", "IsDeleted", "LastModifiedDate", "LastModifiedUserId", "ParentId", "Title" },
				values: new object[,]
				{
					{ 1L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("ea67d95c-ad10-429b-8728-fedc442c987a"), true, false, null, null, null, "ایران" },
					{ 2L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("dba40481-3887-4d1b-84cb-df0e9b68b7a6"), true, false, null, null, null, "اتریش" },
					{ 3L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("b12672cd-2f24-4c3f-b21e-26f1244b79ca"), true, false, null, null, null, "اتیوپی" },
					{ 4L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("02accc92-03a3-4a93-9688-da2deddaf284"), true, false, null, null, null, "اردن" },
					{ 5L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("6cecf227-0773-4918-8a4c-22a5d123a824"), true, false, null, null, null, "ارمنستان" },
					{ 6L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("fb6689e8-65be-464f-b342-b44b9e7c2943"), true, false, null, null, null, "اروگوئه" },
					{ 7L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("f9b9f626-d16a-4d98-8b3b-8082ca392e17"), true, false, null, null, null, "اریتره" },
					{ 8L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("b0caff84-9017-4553-8f8d-b44750585ff7"), true, false, null, null, null, "ازبکستان" },
					{ 9L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("9941ffc5-135b-416d-80d2-533b99b60a1f"), true, false, null, null, null, "اسپانیا" },
					{ 10L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("0a151f0c-ee74-4e43-be68-3cf59984f0dc"), true, false, null, null, null, "استرالیا" },
					{ 11L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("4888d06e-5795-4858-bdd2-be18b36cc60a"), true, false, null, null, null, "استونی" },
					{ 12L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("7d9e9680-5cde-421b-ab43-ec05a2ee0cff"), true, false, null, null, null, "اسرائیل" },
					{ 13L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("23afda54-e86a-4d4a-9f59-5c572cf72245"), true, false, null, null, null, "اسلواکی" },
					{ 14L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("a4a77f00-05ee-47dd-aef7-2d3497e973ae"), true, false, null, null, null, "اسلوونی" },
					{ 15L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("f8d3cf33-78ce-4900-b672-75320b4b5d9c"), true, false, null, null, null, "اسواتینی" },
					{ 16L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("ee5198a1-ad54-40e4-9680-30f25ef9abb2"), true, false, null, null, null, "افغانستان" },
					{ 17L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("c3e7c672-bcf4-48b3-9c1b-5bf5a598c929"), true, false, null, null, null, "اکوادور" },
					{ 18L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("37c27644-5427-4af7-b728-d860082a366f"), true, false, null, null, null, "الجزایر" },
					{ 19L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("a26c68f8-a25b-46c5-9d3b-e9855df2285a"), true, false, null, null, null, "السالوادور" },
					{ 20L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("18a49860-1390-495c-a2c4-39cc53417f9d"), true, false, null, null, null, "امارات متحده عربی" },
					{ 21L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("d31cf596-a955-403f-b7ca-0ec7de30634e"), true, false, null, null, null, "اندونزی" },
					{ 22L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("8a754871-a975-4a16-95e2-0caecf02d0b8"), true, false, null, null, null, "اوکراین" },
					{ 23L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("6af49f3c-aa47-46f6-9627-2250516d5ca0"), true, false, null, null, null, "اوگاندا" },
					{ 24L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("7945befd-8230-4f05-aded-fc21b0e63b75"), true, false, null, null, null, "ایالات متحده آمریکا" },
					{ 25L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("03cf2aa2-8aeb-4060-a727-9c9a6c5f57a8"), true, false, null, null, null, "ایتالیا" },
					{ 26L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("ff3e83d7-57a3-487c-99f0-0a7a6973314e"), true, false, null, null, null, "ایرلند" },
					{ 27L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("ae2adfad-3769-48a4-a1db-d5958d4e9f4f"), true, false, null, null, null, "ایسلند" },
					{ 28L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("19098dde-03cf-43d9-8e55-906850ba015e"), true, false, null, null, null, "آذربایجان" },
					{ 29L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("49b760d0-493a-4125-8465-7f40dfe21604"), true, false, null, null, null, "آرژانتین" },
					{ 30L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("c5b15fca-a561-4ca9-b7b1-ac0cb0aa5660"), true, false, null, null, null, "آفریقای جنوبی" },
					{ 31L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("06193b94-c92e-4c2f-9df1-4d1a0b48de1b"), true, false, null, null, null, "آلبانی" },
					{ 32L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("37dfd360-f35e-4627-9fdd-cf1612c09706"), true, false, null, null, null, "آلمان" },
					{ 33L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("d6c658a9-3618-4f63-b36f-b908176e3a3e"), true, false, null, null, null, "آنتیگوا و باربودا" },
					{ 34L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("0f04c3c7-f366-4202-9d16-4461d4744750"), true, false, null, null, null, "آندورا" },
					{ 35L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("1793565d-79ba-45e7-b329-bd3f210a03d5"), true, false, null, null, null, "آنگولا" },
					{ 36L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("42d9a72f-d771-47f3-8016-21fcba8fd5d4"), true, false, null, null, null, "باربادوس" },
					{ 37L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("f01ea438-2b30-4193-b1be-5f05e3564e7a"), true, false, null, null, null, "باهاما" },
					{ 38L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("82efb60a-f6ac-4853-821f-dba8d004d529"), true, false, null, null, null, "بحرین" },
					{ 39L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("974be3e7-67d3-400b-8aeb-ae567300fb92"), true, false, null, null, null, "برزیل" },
					{ 40L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("d5154c2d-adb1-49ae-a724-be1b7a046d8f"), true, false, null, null, null, "برونئی" },
					{ 41L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("829bd688-6ab9-4f7a-9f55-f0e5bc075c48"), true, false, null, null, null, "بریتانیا" },
					{ 42L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("44628ef5-1d76-49a6-95d7-00cc99e88eb0"), true, false, null, null, null, "بلاروس" },
					{ 43L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("08bcf714-3cb1-4803-9f05-e9726518d44e"), true, false, null, null, null, "بلژیک" },
					{ 44L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("574a74a2-382b-4e9f-81fe-d7cfd1090cf5"), true, false, null, null, null, "بلغارستان" },
					{ 45L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("a94285bf-710a-4cec-bb66-1b15a1b46c5f"), true, false, null, null, null, "بلیز" },
					{ 46L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("e6996240-d921-4818-b630-5678c06216bb"), true, false, null, null, null, "بنگلادش" },
					{ 47L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("7b1b225a-6bb6-4017-8804-98208b6dab93"), true, false, null, null, null, "بنین" },
					{ 48L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("9bcf9c3e-148d-4624-9d6f-4c75e8a80ae5"), true, false, null, null, null, "بوتان" },
					{ 49L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("c5983511-8f11-49e8-9178-3a20301fc3d9"), true, false, null, null, null, "بوتسوانا" },
					{ 50L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("fd8f07c4-4e44-4d05-9bde-261217ef4e5d"), true, false, null, null, null, "بورکینافاسو" },
					{ 51L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("cf0bca8d-8e40-4dc2-a942-98e820630afb"), true, false, null, null, null, "بوروندی" },
					{ 52L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("f5396c20-3743-478d-b17c-d82f07fca587"), true, false, null, null, null, "بوسنی و هرزگوین" },
					{ 53L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("69ba38f9-903a-49ec-b928-8b41dc10b474"), true, false, null, null, null, "بولیوی" },
					{ 54L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("0ef730ec-93a9-46dc-8ac0-30e6033062df"), true, false, null, null, null, "پاپوآ گینه نو" },
					{ 55L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("b8ac1ff0-c692-4282-9f13-94629cafdabf"), true, false, null, null, null, "پاراگوئه" },
					{ 56L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("e172a0cc-cbe3-4720-9c00-4ae61bdc7824"), true, false, null, null, null, "پاکستان" },
					{ 57L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("e4bde8dd-6ac8-417c-809f-458de1a157ef"), true, false, null, null, null, "پالائو" },
					{ 58L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("6583b2b9-b0df-4b4f-8ba4-5307bacf9247"), true, false, null, null, null, "پاناما" },
					{ 59L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("16ab9e30-4b32-4f2e-9068-bf5487b498a1"), true, false, null, null, null, "پرتغال" },
					{ 60L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("0b2e9589-d298-4f57-9eb5-5d530f3dda6a"), true, false, null, null, null, "پرو" },
					{ 61L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("4fe5800a-106a-4edc-8c5f-40ac08706d9d"), true, false, null, null, null, "تاجیکستان" },
					{ 62L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("9256776f-53df-452b-a87c-4a3086a451cd"), true, false, null, null, null, "تانزانیا" },
					{ 63L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("8545d4a8-5939-49d6-9c73-12af1de0a7b7"), true, false, null, null, null, "تایلند" },
					{ 64L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("ecb47318-38ba-4672-a9bf-e2132f8207e8"), true, false, null, null, null, "تایوان" },
					{ 65L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("646eefd1-6a3e-4127-88eb-d46cfe994076"), true, false, null, null, null, "ترکمنستان" },
					{ 66L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("82ab027b-bde3-4ee9-a217-4073bcea57b0"), true, false, null, null, null, "ترکیه" },
					{ 67L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("dbeecb7a-2d43-401f-b3a9-b46bdf87c29b"), true, false, null, null, null, "ترینیداد و توباگو" },
					{ 68L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("7bbf3ce3-81de-4423-a7c9-dc14068d03d2"), true, false, null, null, null, "توگو" },
					{ 69L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("a16b2315-c803-4bed-ac69-214c6cde3ff3"), true, false, null, null, null, "تونس" },
					{ 70L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("a18dafc6-11a4-4920-9e42-5983e6758d12"), true, false, null, null, null, "تونگا" },
					{ 71L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("2ae85d9e-33c7-4674-b1ca-e0581c48178a"), true, false, null, null, null, "تووالو" },
					{ 72L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("2941f4f3-249f-40bb-a1e6-6a830f4b7f1d"), true, false, null, null, null, "تیمور شرقی" },
					{ 73L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("64b19cd3-2416-494a-bf23-d368a5ea607c"), true, false, null, null, null, "جامائیکا" },
					{ 74L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("71670711-68e9-4123-b7ce-c063b3fd910c"), true, false, null, null, null, "جزایر سلیمان" },
					{ 75L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("51b29a7d-31da-4985-913a-61938ad800fb"), true, false, null, null, null, "جزایر مارشال" },
					{ 76L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("8907d046-60fb-4029-83e1-76fdb247a47e"), true, false, null, null, null, "جمهوری آفریقای مرکزی" },
					{ 77L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("8bba3ab9-94b4-4d05-b1a3-c8fe0ec31fca"), true, false, null, null, null, "جمهوری چک" },
					{ 78L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("9454e54f-8b7f-4a85-9156-1ed7013d6554"), true, false, null, null, null, "جمهوری دموکراتیک کنگو" },
					{ 79L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("534a678b-4de4-46f6-b2ea-e54d4c1c4d77"), true, false, null, null, null, "جمهوری دومینیکن" },
					{ 80L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("e8926da2-654d-4d6b-b0e2-9f680d3c12ae"), true, false, null, null, null, "جیبوتی" },
					{ 81L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("944c7c9f-8a26-444f-8a7e-facf94051eac"), true, false, null, null, null, "چاد" },
					{ 82L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("596b2813-6a09-4929-818e-408b8435334b"), true, false, null, null, null, "چین" },
					{ 83L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("c9419815-19f5-40e6-a8b4-aa5abcf168db"), true, false, null, null, null, "دانمارک" },
					{ 84L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("72943d44-301b-4a4d-a4a7-7553a476ee30"), true, false, null, null, null, "دومینیکا" },
					{ 85L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("63e77fd3-401f-4537-a08d-3f0c9be56c57"), true, false, null, null, null, "رواندا" },
					{ 86L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("feabdbd4-6e46-476e-862f-ae052d515509"), true, false, null, null, null, "روسیه" },
					{ 87L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("f9aa5d38-8868-4d30-8ffc-78b72ccaf66f"), true, false, null, null, null, "رومانی" },
					{ 88L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("ba0c8ff9-df2a-4959-a859-b4f69c156c56"), true, false, null, null, null, "زامبیا" },
					{ 89L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("6967f5c5-a163-484b-b531-67499ece9684"), true, false, null, null, null, "زیمبابوه" },
					{ 90L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("9ed263f4-bec0-4355-81f2-f517c608e8e9"), true, false, null, null, null, "ژاپن" },
					{ 91L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("52349af2-40ce-4750-bebc-5c651574bbf5"), true, false, null, null, null, "ساحل عاج" },
					{ 92L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("3072df6c-b487-4d5a-ba7e-15570326808a"), true, false, null, null, null, "ساموآ" },
					{ 93L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("460655db-dc6f-4d1e-9627-74c884064965"), true, false, null, null, null, "سان مارینو" },
					{ 94L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("241a6ce3-f197-4a57-9804-16b9ebd377e3"), true, false, null, null, null, "سائوتومه و پرنسیپ" },
					{ 95L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("82189184-2fef-4cf3-844c-126bc4fb4930"), true, false, null, null, null, "سریلانکا" },
					{ 96L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("72bb39f1-ed98-4bfc-a6a4-50a01f29f866"), true, false, null, null, null, "سنت کیتس و نویس" },
					{ 97L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("61174fc7-6892-428b-8eb9-5e3233611775"), true, false, null, null, null, "سنت لوسیا" },
					{ 98L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("c5abf2d1-c46a-40fa-b0ac-e94e315c8e72"), true, false, null, null, null, "سنت وینسنت و گرنادین‌ها" },
					{ 99L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("5ed434c6-86ab-483e-8c5d-bff02a5caca9"), true, false, null, null, null, "سنگاپور" },
					{ 100L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("8c00f1f3-1b34-46a7-a339-144c3630cac1"), true, false, null, null, null, "سنگال" },
					{ 101L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("6d2c2d2f-fa35-40fa-ae36-7074aa8a7a85"), true, false, null, null, null, "سودان" },
					{ 102L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("7c4097b3-5a9e-4db8-a2fc-6f0d483f82ef"), true, false, null, null, null, "سودان جنوبی" },
					{ 103L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("6a2cff8b-5b23-42c7-aeb4-556acbfe7789"), true, false, null, null, null, "سورینام" },
					{ 104L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("dc026177-6086-41c6-a5d3-028a739cfb75"), true, false, null, null, null, "سوریه" },
					{ 105L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("211c75b7-f28b-49e7-aa37-1704b88391e9"), true, false, null, null, null, "سومالی" },
					{ 106L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("aaf2ae71-ce64-4653-bd12-96b5915bef60"), true, false, null, null, null, "سوئد" },
					{ 107L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("0239b492-88f1-4a79-bc6e-ed7504fe1e04"), true, false, null, null, null, "سوئیس" },
					{ 108L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("38f5e4da-97fa-4c0a-b363-95d0f79e50e2"), true, false, null, null, null, "سیرالئون" },
					{ 109L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("557a987f-6d11-4153-a509-fa957ca46641"), true, false, null, null, null, "سیشل" },
					{ 110L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("5ad7ad45-cc49-47c8-b8c9-0b46e6df44dc"), true, false, null, null, null, "شیلی" },
					{ 111L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("e4b4a865-070b-4b5c-b5f1-0e4d7d58d157"), true, false, null, null, null, "صربستان" },
					{ 112L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("7a61b61d-d000-42b0-8ac6-920e952862eb"), true, false, null, null, null, "عراق" },
					{ 113L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("042a6800-a977-443a-b4dc-e8e64487af3c"), true, false, null, null, null, "عربستان سعودی" },
					{ 114L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("d40cd87b-87a5-415c-a6a8-fbefe462f94b"), true, false, null, null, null, "عمان" },
					{ 115L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("bf6e1716-5a00-46c0-87fa-87028b9c998b"), true, false, null, null, null, "غنا" },
					{ 116L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("7a6f2e43-4c90-40be-bfe9-bc99362f0b03"), true, false, null, null, null, "فرانسه" },
					{ 117L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("f6bd0340-eb87-4992-b183-0c02874ef0ca"), true, false, null, null, null, "فنلاند" },
					{ 118L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("db986c8d-278c-4d5e-8db4-0605c90ee1c0"), true, false, null, null, null, "فیجی" },
					{ 119L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("a1fbdb80-8b0a-4c5e-89e6-94f6f1efd7d4"), true, false, null, null, null, "فیلیپین" },
					{ 120L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("bfa9650b-f5b4-4a00-bd71-fdcd529a36f5"), true, false, null, null, null, "قبرس" },
					{ 121L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("6eccab95-88d7-49f2-bce7-b3302486f41f"), true, false, null, null, null, "قرقیزستان" },
					{ 122L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("df6954ce-4799-4eee-995e-7309b0033e12"), true, false, null, null, null, "قزاقستان" },
					{ 123L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("ea299b56-18be-4c7b-a17c-8f6a943ef588"), true, false, null, null, null, "قطر" },
					{ 124L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("842512b3-ffc8-4b90-8aa1-2894e439cf32"), true, false, null, null, null, "کاستاریکا" },
					{ 125L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("57f09ae8-6dcb-4128-8ef7-04e42aa20074"), true, false, null, null, null, "کامبوج" },
					{ 126L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("d49befa8-69f1-4951-8d32-dd733f6728c9"), true, false, null, null, null, "کامرون" },
					{ 127L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("aaf60d27-1902-4880-876a-43c66b9e5439"), true, false, null, null, null, "کانادا" },
					{ 128L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("533c1fba-a407-4a63-a490-91219504671e"), true, false, null, null, null, "کره جنوبی" },
					{ 129L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("336ba65c-49ff-48fc-992a-d7f64b7f452f"), true, false, null, null, null, "کره شمالی" },
					{ 130L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("9898ed60-e11c-4f38-8635-47ea1e548a78"), true, false, null, null, null, "کرواسی" },
					{ 131L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("5bb1f0c8-384a-47db-a626-cfe7e9e24d29"), true, false, null, null, null, "کلمبیا" },
					{ 132L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("ba7db685-0c8e-4287-a2a8-4934ff627c85"), true, false, null, null, null, "کنگو" },
					{ 133L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("1c14a119-bf8b-462d-a5d5-7f221ce4a630"), true, false, null, null, null, "کنیا" },
					{ 134L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("fe4e11d2-0565-4317-be62-fff05bbfa0df"), true, false, null, null, null, "کوبا" },
					{ 135L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("1855a9e5-6b40-401d-a71f-d17aaf5b3942"), true, false, null, null, null, "کومور" },
					{ 136L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("ea3d8e10-9b7e-436e-96af-dc6dd44f0805"), true, false, null, null, null, "کویت" },
					{ 137L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("2cee913c-86b6-4617-b135-66aefb6106d1"), true, false, null, null, null, "کیپ ورد" },
					{ 138L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("4e8da8c5-264a-43a9-9cb2-de0c9f343cfa"), true, false, null, null, null, "کیریباتی" },
					{ 139L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("d95ed732-d417-47a9-a8c8-102929320b28"), true, false, null, null, null, "گابن" },
					{ 140L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("ecc59c8a-9104-4148-8e7b-d640028ae409"), true, false, null, null, null, "گامبیا" },
					{ 141L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("27af0861-bf33-4369-85d6-621ea7fee83e"), true, false, null, null, null, "گرجستان" },
					{ 142L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("7cfa99e3-f372-4961-8405-147f95e8e2c1"), true, false, null, null, null, "گرنادا" },
					{ 143L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("11a7cf15-d34e-44bc-b9b5-1ffab378ef37"), true, false, null, null, null, "گواتمالا" },
					{ 144L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("cf1110a0-78f8-47dd-af27-c65d06cf92fe"), true, false, null, null, null, "گویان" },
					{ 145L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("2c2965cd-936a-484b-899f-f1c25d6c8f9b"), true, false, null, null, null, "گینه" },
					{ 146L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("bef19367-e367-4ebd-b273-459cdd00648a"), true, false, null, null, null, "گینه استوایی" },
					{ 147L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("ba16ab33-624f-4a5d-a591-8dd62b366647"), true, false, null, null, null, "گینه بیسائو" },
					{ 148L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("952c2f01-01e8-4634-87a9-4161d0ef990e"), true, false, null, null, null, "لائوس" },
					{ 149L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("e03a3b24-a8d7-489c-aee5-f6f9338cad7e"), true, false, null, null, null, "لبنان" },
					{ 150L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("d7fec80f-4b9b-4d15-b02b-1e11be4208e4"), true, false, null, null, null, "لتونی" },
					{ 151L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("f90e7090-d304-4ddc-a622-c255ff735b2e"), true, false, null, null, null, "لسوتو" },
					{ 152L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("c6051f9b-1bb8-4a49-b97a-cc346ce14102"), true, false, null, null, null, "لهستان" },
					{ 153L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("64e1ed61-2efa-480d-8302-4ccdb5833c4e"), true, false, null, null, null, "لوکزامبورگ" },
					{ 154L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("352842c2-f915-4dd8-919a-655127326f35"), true, false, null, null, null, "لیبریا" },
					{ 155L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("c86b6877-10c5-403b-a286-c98e3ef1fac6"), true, false, null, null, null, "لیبی" },
					{ 156L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("ea2b5b80-9798-4e65-96b7-ff722f3562a5"), true, false, null, null, null, "لیتوانی" },
					{ 157L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("fd4aff57-e630-48f3-9c2a-3f622261a0bf"), true, false, null, null, null, "لیختن‌اشتاین" },
					{ 158L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("b88e6b8f-3748-4b35-bf75-7f3dec64d733"), true, false, null, null, null, "ماداگاسکار" },
					{ 159L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("b0bb9847-5596-45ae-a85b-f845ace4b565"), true, false, null, null, null, "مالاوی" },
					{ 160L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("10f55935-b892-4a1a-bb92-48cc591ae490"), true, false, null, null, null, "مالت" },
					{ 161L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("35e36402-8e14-43c1-bcad-6deedf8a4c10"), true, false, null, null, null, "مالدیو" },
					{ 162L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("99ca268a-e218-48b8-9569-e10d2e17e350"), true, false, null, null, null, "مالزی" },
					{ 163L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("ac98441f-7076-4934-b16a-12d8fad02368"), true, false, null, null, null, "مالی" },
					{ 164L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("24f095f4-b678-4292-bc77-03ae0fc545b9"), true, false, null, null, null, "مجارستان" },
					{ 165L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("03913eb3-80a6-463d-9c1d-36f308099db5"), true, false, null, null, null, "مراکش" },
					{ 166L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("238ad5e5-e39b-40ee-8b38-37ef84f8dda5"), true, false, null, null, null, "مصر" },
					{ 167L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("286be713-4598-49ce-b599-a1eee83ea7fa"), true, false, null, null, null, "مغولستان" },
					{ 168L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("dadae484-048d-4063-826c-5479c7633f4b"), true, false, null, null, null, "مقدونیه شمالی" },
					{ 169L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("3be159fd-38e8-4244-8f8a-7e4105f2bc84"), true, false, null, null, null, "مکزیک" },
					{ 170L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("4a3bf462-850a-4856-82b2-3d9a7daade61"), true, false, null, null, null, "موریتانی" },
					{ 171L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("41490960-34e5-49f5-97e0-cfc66460c38d"), true, false, null, null, null, "موریس" },
					{ 172L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("35d25127-9e9a-4c51-a1ab-0e46bcd2f737"), true, false, null, null, null, "موزامبیک" },
					{ 173L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("b6a893c3-bfde-4a9f-8844-15812e56f93b"), true, false, null, null, null, "مولداوی" },
					{ 174L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("c9ef31c0-0b76-41bb-ad94-367824440e0c"), true, false, null, null, null, "موناکو" },
					{ 175L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("762f949d-ba05-464b-840b-512d66415f36"), true, false, null, null, null, "مونته‌نگرو" },
					{ 176L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("9dbd70af-d2c1-4f4d-a1de-c7590ff02645"), true, false, null, null, null, "میانمار" },
					{ 177L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("8b13e51f-7358-42f0-a7a7-4af7c98d112d"), true, false, null, null, null, "میکرونزی" },
					{ 178L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("69c1fd2e-2d3b-4da5-b62b-ea5bfb964769"), true, false, null, null, null, "نامیبیا" },
					{ 179L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("b18c2f14-643c-4b3f-8b27-cd2a4b76dad8"), true, false, null, null, null, "نائورو" },
					{ 180L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("b1a78b07-d79b-48c3-ac33-b393ca3da8a4"), true, false, null, null, null, "نپال" },
					{ 181L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("e89b19b6-a77c-4ef4-bd05-797abb54e91a"), true, false, null, null, null, "نروژ" },
					{ 182L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("4c226a21-866b-4777-9a43-c97e5ff448f9"), true, false, null, null, null, "نیجر" },
					{ 183L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("60736172-d6a3-487a-8785-35a8e97d2693"), true, false, null, null, null, "نیجریه" },
					{ 184L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("e77738d8-19eb-47f9-8528-f017d24cedd4"), true, false, null, null, null, "نیکاراگوئه" },
					{ 185L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("c84ca578-64e7-48a4-a51f-819981f235c0"), true, false, null, null, null, "نیوزیلند" },
					{ 186L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("87aa5985-0dff-4697-87bb-8d8b262d76bf"), true, false, null, null, null, "هائیتی" },
					{ 187L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("54de3018-d48f-43a4-b903-3c0bf4b12f18"), true, false, null, null, null, "هلند" },
					{ 188L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("07e8bc73-693d-4791-9f02-f0ab22e1c804"), true, false, null, null, null, "هند" },
					{ 189L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("8c4a1f30-4e9a-4441-9f28-dacee01b79bf"), true, false, null, null, null, "هندوراس" },
					{ 190L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("9319055f-bc38-46dc-90c0-98a6ca3fb306"), true, false, null, null, null, "واتیکان" },
					{ 191L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("a92d7141-0d95-4373-ad63-61e329885a4c"), true, false, null, null, null, "وانواتو" },
					{ 192L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("553d7dcf-11a3-4e18-aaa8-62db8d2d625d"), true, false, null, null, null, "ونزوئلا" },
					{ 193L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("aa5d32e6-3369-43aa-ae29-c59e865be2f5"), true, false, null, null, null, "ویتنام" },
					{ 194L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("ab26cb1a-fde4-4aa0-8dce-faa6bb5cdbdc"), true, false, null, null, null, "یمن" },
					{ 195L, new DateTime(2026, 3, 25, 4, 20, 23, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("4cb19af0-88cc-4e63-bcb3-dcbff6bd6dd3"), true, false, null, null, null, "یونان" },
					{ 196L, new DateTime(2026, 3, 25, 4, 22, 14, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("ea67d95c-ad10-429b-8728-fedc442c987a"), true, false, null, null, 1L, "اردبیل" },
					{ 197L, new DateTime(2026, 3, 25, 4, 22, 14, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("dba40481-3887-4d1b-84cb-df0e9b68b7a6"), true, false, null, null, 1L, "اصفهان" },
					{ 198L, new DateTime(2026, 3, 25, 4, 22, 14, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("b12672cd-2f24-4c3f-b21e-26f1244b79ca"), true, false, null, null, 1L, "البرز" },
					{ 199L, new DateTime(2026, 3, 25, 4, 22, 14, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("02accc92-03a3-4a93-9688-da2deddaf284"), true, false, null, null, 1L, "ایلام" },
					{ 200L, new DateTime(2026, 3, 25, 4, 22, 14, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("6cecf227-0773-4918-8a4c-22a5d123a824"), true, false, null, null, 1L, "آذربایجان شرقی" },
					{ 201L, new DateTime(2026, 3, 25, 4, 22, 14, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("fb6689e8-65be-464f-b342-b44b9e7c2943"), true, false, null, null, 1L, "آذربایجان غربی" },
					{ 202L, new DateTime(2026, 3, 25, 4, 22, 14, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("f9b9f626-d16a-4d98-8b3b-8082ca392e17"), true, false, null, null, 1L, "بوشهر" },
					{ 203L, new DateTime(2026, 3, 25, 4, 22, 14, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("b0caff84-9017-4553-8f8d-b44750585ff7"), true, false, null, null, 1L, "تهران" },
					{ 204L, new DateTime(2026, 3, 25, 4, 22, 14, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("9941ffc5-135b-416d-80d2-533b99b60a1f"), true, false, null, null, 1L, "چهارمحال و بختیاری" },
					{ 205L, new DateTime(2026, 3, 25, 4, 22, 14, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("0a151f0c-ee74-4e43-be68-3cf59984f0dc"), true, false, null, null, 1L, "خراسان جنوبی" },
					{ 206L, new DateTime(2026, 3, 25, 4, 22, 14, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("4888d06e-5795-4858-bdd2-be18b36cc60a"), true, false, null, null, 1L, "خراسان رضوی" },
					{ 207L, new DateTime(2026, 3, 25, 4, 22, 14, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("7d9e9680-5cde-421b-ab43-ec05a2ee0cff"), true, false, null, null, 1L, "خراسان شمالی" },
					{ 208L, new DateTime(2026, 3, 25, 4, 22, 14, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("23afda54-e86a-4d4a-9f59-5c572cf72245"), true, false, null, null, 1L, "خوزستان" },
					{ 209L, new DateTime(2026, 3, 25, 4, 22, 14, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("a4a77f00-05ee-47dd-aef7-2d3497e973ae"), true, false, null, null, 1L, "زنجان" },
					{ 210L, new DateTime(2026, 3, 25, 4, 22, 14, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("f8d3cf33-78ce-4900-b672-75320b4b5d9c"), true, false, null, null, 1L, "سمنان" },
					{ 211L, new DateTime(2026, 3, 25, 4, 22, 14, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("ee5198a1-ad54-40e4-9680-30f25ef9abb2"), true, false, null, null, 1L, "سیستان و بلوچستان" },
					{ 212L, new DateTime(2026, 3, 25, 4, 22, 14, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("c3e7c672-bcf4-48b3-9c1b-5bf5a598c929"), true, false, null, null, 1L, "فارس" },
					{ 213L, new DateTime(2026, 3, 25, 4, 22, 14, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("37c27644-5427-4af7-b728-d860082a366f"), true, false, null, null, 1L, "قزوین" },
					{ 214L, new DateTime(2026, 3, 25, 4, 22, 14, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("a26c68f8-a25b-46c5-9d3b-e9855df2285a"), true, false, null, null, 1L, "قم" },
					{ 215L, new DateTime(2026, 3, 25, 4, 22, 14, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("18a49860-1390-495c-a2c4-39cc53417f9d"), true, false, null, null, 1L, "کردستان" },
					{ 216L, new DateTime(2026, 3, 25, 4, 22, 14, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("d31cf596-a955-403f-b7ca-0ec7de30634e"), true, false, null, null, 1L, "کرمان" },
					{ 217L, new DateTime(2026, 3, 25, 4, 22, 14, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("8a754871-a975-4a16-95e2-0caecf02d0b8"), true, false, null, null, 1L, "کرمانشاه" },
					{ 218L, new DateTime(2026, 3, 25, 4, 22, 14, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("6af49f3c-aa47-46f6-9627-2250516d5ca0"), true, false, null, null, 1L, "کهگیلویه و بویراحمد" },
					{ 219L, new DateTime(2026, 3, 25, 4, 22, 14, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("7945befd-8230-4f05-aded-fc21b0e63b75"), true, false, null, null, 1L, "گلستان" },
					{ 220L, new DateTime(2026, 3, 25, 4, 22, 14, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("03cf2aa2-8aeb-4060-a727-9c9a6c5f57a8"), true, false, null, null, 1L, "گیلان" },
					{ 221L, new DateTime(2026, 3, 25, 4, 22, 14, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("ff3e83d7-57a3-487c-99f0-0a7a6973314e"), true, false, null, null, 1L, "لرستان" },
					{ 222L, new DateTime(2026, 3, 25, 4, 22, 14, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("ae2adfad-3769-48a4-a1db-d5958d4e9f4f"), true, false, null, null, 1L, "مازندران" },
					{ 223L, new DateTime(2026, 3, 25, 4, 22, 14, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("19098dde-03cf-43d9-8e55-906850ba015e"), true, false, null, null, 1L, "مرکزی" },
					{ 224L, new DateTime(2026, 3, 25, 4, 22, 14, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("49b760d0-493a-4125-8465-7f40dfe21604"), true, false, null, null, 1L, "هرمزگان" },
					{ 225L, new DateTime(2026, 3, 25, 4, 22, 14, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("c5b15fca-a561-4ca9-b7b1-ac0cb0aa5660"), true, false, null, null, 1L, "همدان" },
					{ 226L, new DateTime(2026, 3, 25, 4, 22, 14, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("06193b94-c92e-4c2f-9df1-4d1a0b48de1b"), true, false, null, null, 1L, "یزد" },
					{ 227L, new DateTime(2026, 3, 25, 4, 22, 14, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("37dfd360-f35e-4627-9fdd-cf1612c09706"), true, false, null, null, 24L, "اوهایو" },
					{ 228L, new DateTime(2026, 3, 25, 4, 22, 14, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("d6c658a9-3618-4f63-b36f-b908176e3a3e"), true, false, null, null, 24L, "ایلینوی" },
					{ 229L, new DateTime(2026, 3, 25, 4, 22, 14, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("0f04c3c7-f366-4202-9d16-4461d4744750"), true, false, null, null, 24L, "آریزونا" },
					{ 230L, new DateTime(2026, 3, 25, 4, 22, 14, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("1793565d-79ba-45e7-b329-bd3f210a03d5"), true, false, null, null, 24L, "پنسیلوانیا" },
					{ 231L, new DateTime(2026, 3, 25, 4, 22, 14, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("42d9a72f-d771-47f3-8016-21fcba8fd5d4"), true, false, null, null, 24L, "تگزاس" },
					{ 232L, new DateTime(2026, 3, 25, 4, 22, 14, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("f01ea438-2b30-4193-b1be-5f05e3564e7a"), true, false, null, null, 24L, "جورجیا" },
					{ 233L, new DateTime(2026, 3, 25, 4, 22, 14, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("82efb60a-f6ac-4853-821f-dba8d004d529"), true, false, null, null, 24L, "فلوریدا" },
					{ 234L, new DateTime(2026, 3, 25, 4, 22, 14, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("974be3e7-67d3-400b-8aeb-ae567300fb92"), true, false, null, null, 24L, "کارولینای شمالی" },
					{ 235L, new DateTime(2026, 3, 25, 4, 22, 14, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("d5154c2d-adb1-49ae-a724-be1b7a046d8f"), true, false, null, null, 24L, "ماساچوست" },
					{ 236L, new DateTime(2026, 3, 25, 4, 22, 14, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("829bd688-6ab9-4f7a-9f55-f0e5bc075c48"), true, false, null, null, 24L, "میشیگان" },
					{ 237L, new DateTime(2026, 3, 25, 4, 22, 14, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("44628ef5-1d76-49a6-95d7-00cc99e88eb0"), true, false, null, null, 24L, "نیوجرسی" },
					{ 238L, new DateTime(2026, 3, 25, 4, 22, 14, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("08bcf714-3cb1-4803-9f05-e9726518d44e"), true, false, null, null, 24L, "نیویورک" },
					{ 239L, new DateTime(2026, 3, 25, 4, 22, 14, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("574a74a2-382b-4e9f-81fe-d7cfd1090cf5"), true, false, null, null, 24L, "واشینگتن" },
					{ 240L, new DateTime(2026, 3, 25, 4, 22, 14, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("a94285bf-710a-4cec-bb66-1b15a1b46c5f"), true, false, null, null, 24L, "ویرجینیا" },
					{ 241L, new DateTime(2026, 3, 25, 4, 22, 14, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("e6996240-d921-4818-b630-5678c06216bb"), true, false, null, null, 127L, "آلبرتا" },
					{ 242L, new DateTime(2026, 3, 25, 4, 22, 14, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("7b1b225a-6bb6-4017-8804-98208b6dab93"), true, false, null, null, 127L, "بریتیش کلمبیا" },
					{ 243L, new DateTime(2026, 3, 25, 4, 22, 14, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("9bcf9c3e-148d-4624-9d6f-4c75e8a80ae5"), true, false, null, null, 127L, "جزیره پرنس ادوارد" },
					{ 244L, new DateTime(2026, 3, 25, 4, 22, 14, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("c5983511-8f11-49e8-9178-3a20301fc3d9"), true, false, null, null, 127L, "ساسکاچوان" },
					{ 245L, new DateTime(2026, 3, 25, 4, 22, 14, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("fd8f07c4-4e44-4d05-9bde-261217ef4e5d"), true, false, null, null, 127L, "کبک" },
					{ 246L, new DateTime(2026, 3, 25, 4, 22, 14, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("cf0bca8d-8e40-4dc2-a942-98e820630afb"), true, false, null, null, 127L, "مانیتوبا" },
					{ 247L, new DateTime(2026, 3, 25, 4, 22, 14, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("f5396c20-3743-478d-b17c-d82f07fca587"), true, false, null, null, 127L, "نوا اسکوشیا" },
					{ 248L, new DateTime(2026, 3, 25, 4, 22, 14, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("69ba38f9-903a-49ec-b928-8b41dc10b474"), true, false, null, null, 127L, "نیوبرانزویک" },
					{ 249L, new DateTime(2026, 3, 25, 4, 22, 14, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("0ef730ec-93a9-46dc-8ac0-30e6033062df"), true, false, null, null, 127L, "نیوفاندلند و لابرادور" },
					{ 250L, new DateTime(2026, 3, 25, 4, 22, 14, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("b8ac1ff0-c692-4282-9f13-94629cafdabf"), true, false, null, null, 32L, "بادن-وورتمبرگ" },
					{ 251L, new DateTime(2026, 3, 25, 4, 22, 14, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("e172a0cc-cbe3-4720-9c00-4ae61bdc7824"), true, false, null, null, 32L, "براندنبورگ" },
					{ 252L, new DateTime(2026, 3, 25, 4, 22, 14, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("e4bde8dd-6ac8-417c-809f-458de1a157ef"), true, false, null, null, 32L, "برلین" },
					{ 253L, new DateTime(2026, 3, 25, 4, 22, 14, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("6583b2b9-b0df-4b4f-8ba4-5307bacf9247"), true, false, null, null, 32L, "زاکسن" },
					{ 254L, new DateTime(2026, 3, 25, 4, 22, 14, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("16ab9e30-4b32-4f2e-9068-bf5487b498a1"), true, false, null, null, 32L, "شلسویگ-هولشتاین" },
					{ 255L, new DateTime(2026, 3, 25, 4, 22, 14, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("0b2e9589-d298-4f57-9eb5-5d530f3dda6a"), true, false, null, null, 32L, "نوردراین-وستفالن" },
					{ 256L, new DateTime(2026, 3, 25, 4, 22, 14, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("4fe5800a-106a-4edc-8c5f-40ac08706d9d"), true, false, null, null, 32L, "نیدرزاکسن" },
					{ 257L, new DateTime(2026, 3, 25, 4, 22, 14, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("9256776f-53df-452b-a87c-4a3086a451cd"), true, false, null, null, 32L, "هامبورگ" },
					{ 258L, new DateTime(2026, 3, 25, 4, 22, 14, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("8545d4a8-5939-49d6-9c73-12af1de0a7b7"), true, false, null, null, 32L, "هسن" },
					{ 259L, new DateTime(2026, 3, 25, 4, 22, 14, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("ecb47318-38ba-4672-a9bf-e2132f8207e8"), true, false, null, null, 66L, "ازمیر" },
					{ 260L, new DateTime(2026, 3, 25, 4, 22, 14, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("646eefd1-6a3e-4127-88eb-d46cfe994076"), true, false, null, null, 66L, "استانبول" },
					{ 261L, new DateTime(2026, 3, 25, 4, 22, 14, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("82ab027b-bde3-4ee9-a217-4073bcea57b0"), true, false, null, null, 66L, "آدانا" },
					{ 262L, new DateTime(2026, 3, 25, 4, 22, 14, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("dbeecb7a-2d43-401f-b3a9-b46bdf87c29b"), true, false, null, null, 66L, "آنتالیا" },
					{ 263L, new DateTime(2026, 3, 25, 4, 22, 14, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("7bbf3ce3-81de-4423-a7c9-dc14068d03d2"), true, false, null, null, 66L, "آنکارا" },
					{ 264L, new DateTime(2026, 3, 25, 4, 22, 14, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("a16b2315-c803-4bed-ac69-214c6cde3ff3"), true, false, null, null, 66L, "بورسا" },
					{ 265L, new DateTime(2026, 3, 25, 4, 22, 14, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("a18dafc6-11a4-4920-9e42-5983e6758d12"), true, false, null, null, 66L, "ترابزون" },
					{ 266L, new DateTime(2026, 3, 25, 4, 22, 14, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("2ae85d9e-33c7-4674-b1ca-e0581c48178a"), true, false, null, null, 66L, "شانلی‌اورفه" },
					{ 267L, new DateTime(2026, 3, 25, 4, 22, 14, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("2941f4f3-249f-40bb-a1e6-6a830f4b7f1d"), true, false, null, null, 66L, "غازی عینتاب" },
					{ 268L, new DateTime(2026, 3, 25, 4, 22, 14, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("64b19cd3-2416-494a-bf23-d368a5ea607c"), true, false, null, null, 66L, "قونیه" },
					{ 269L, new DateTime(2026, 3, 25, 4, 22, 14, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("71670711-68e9-4123-b7ce-c063b3fd910c"), true, false, null, null, 10L, "استرالیای جنوبی" },
					{ 270L, new DateTime(2026, 3, 25, 4, 22, 14, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("51b29a7d-31da-4985-913a-61938ad800fb"), true, false, null, null, 10L, "استرالیای غربی" },
					{ 271L, new DateTime(2026, 3, 25, 4, 22, 14, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("8907d046-60fb-4029-83e1-76fdb247a47e"), true, false, null, null, 10L, "تاسمانی" },
					{ 272L, new DateTime(2026, 3, 25, 4, 22, 14, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("8bba3ab9-94b4-4d05-b1a3-c8fe0ec31fca"), true, false, null, null, 10L, "قلمرو پایتخت استرالیا" },
					{ 273L, new DateTime(2026, 3, 25, 4, 22, 14, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("9454e54f-8b7f-4a85-9156-1ed7013d6554"), true, false, null, null, 10L, "قلمرو شمالی" },
					{ 274L, new DateTime(2026, 3, 25, 4, 22, 14, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("534a678b-4de4-46f6-b2ea-e54d4c1c4d77"), true, false, null, null, 10L, "کوئینزلند" },
					{ 275L, new DateTime(2026, 3, 25, 4, 22, 14, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("e8926da2-654d-4d6b-b0e2-9f680d3c12ae"), true, false, null, null, 10L, "نیو ساوت ولز" },
					{ 276L, new DateTime(2026, 3, 25, 4, 22, 14, 0, DateTimeKind.Unspecified), null, "Created by seeding data", new Guid("944c7c9f-8a26-444f-8a7e-facf94051eac"), true, false, null, null, 10L, "ویکتوریا" }
				});
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 2L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 3L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 4L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 5L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 6L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 7L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 8L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 9L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 11L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 12L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 13L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 14L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 15L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 16L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 17L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 18L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 19L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 20L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 21L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 22L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 23L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 25L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 26L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 27L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 28L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 29L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 30L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 31L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 33L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 34L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 35L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 36L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 37L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 38L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 39L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 40L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 41L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 42L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 43L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 44L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 45L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 46L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 47L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 48L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 49L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 50L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 51L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 52L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 53L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 54L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 55L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 56L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 57L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 58L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 59L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 60L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 61L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 62L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 63L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 64L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 65L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 67L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 68L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 69L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 70L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 71L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 72L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 73L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 74L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 75L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 76L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 77L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 78L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 79L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 80L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 81L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 82L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 83L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 84L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 85L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 86L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 87L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 88L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 89L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 90L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 91L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 92L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 93L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 94L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 95L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 96L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 97L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 98L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 99L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 100L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 101L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 102L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 103L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 104L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 105L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 106L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 107L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 108L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 109L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 110L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 111L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 112L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 113L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 114L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 115L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 116L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 117L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 118L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 119L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 120L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 121L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 122L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 123L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 124L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 125L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 126L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 128L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 129L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 130L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 131L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 132L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 133L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 134L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 135L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 136L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 137L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 138L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 139L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 140L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 141L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 142L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 143L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 144L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 145L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 146L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 147L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 148L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 149L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 150L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 151L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 152L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 153L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 154L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 155L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 156L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 157L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 158L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 159L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 160L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 161L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 162L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 163L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 164L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 165L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 166L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 167L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 168L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 169L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 170L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 171L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 172L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 173L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 174L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 175L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 176L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 177L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 178L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 179L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 180L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 181L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 182L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 183L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 184L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 185L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 186L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 187L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 188L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 189L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 190L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 191L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 192L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 193L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 194L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 195L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 196L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 197L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 198L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 199L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 200L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 201L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 202L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 203L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 204L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 205L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 206L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 207L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 208L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 209L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 210L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 211L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 212L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 213L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 214L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 215L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 216L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 217L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 218L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 219L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 220L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 221L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 222L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 223L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 224L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 225L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 226L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 227L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 228L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 229L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 230L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 231L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 232L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 233L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 234L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 235L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 236L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 237L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 238L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 239L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 240L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 241L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 242L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 243L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 244L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 245L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 246L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 247L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 248L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 249L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 250L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 251L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 252L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 253L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 254L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 255L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 256L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 257L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 258L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 259L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 260L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 261L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 262L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 263L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 264L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 265L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 266L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 267L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 268L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 269L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 270L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 271L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 272L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 273L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 274L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 275L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 276L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 1L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 10L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 24L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 32L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 66L);

			migrationBuilder.DeleteData(
				table: "States",
				keyColumn: "Id",
				keyValue: 127L);
		}
	}
}
