using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;


public class MigrationConfig : DbMigrationsConfiguration<DBContext>
{
    public MigrationConfig()
    {
        AutomaticMigrationsEnabled = true;
        AutomaticMigrationDataLossAllowed = true;
        ContextKey = "Models.DBContext";
    }
    protected override void Seed(DBContext context)
    {
        base.Seed(context);
        Role r1 = new Role() {RoleId=1, RoleName="Administrator" ,RoleDesc="مدیر سایت" };
        Role r2 = new Role() { RoleId = 2, RoleName = "Member", RoleDesc = "کاربر سایت" };
        User user = new User() {
        UserId=1, UserName="Admin",UserFirstName="admin",
        IsActive=true,
        UserLastName ="admin",Password="Admin",
        UserEmail ="Admin@Admin.com",role=r1
        };
        
        

        context.Roles.AddOrUpdate(r1);
        context.Roles.AddOrUpdate(r2);
        context.Users.AddOrUpdate(user);
        if(context.Setting.Count()==0)
        {
            Setting s = new Setting();
            s.Id = 1;
            s.AboutKefirText = " اگر چه کفیر در درجه اول برای پروبیوتیک‌ها و پروتئین آن مصرف می‌شود، اما از نظر ویتامین‌ها و مواد معدنی نیز باارزش است. یک فنجان کفیر، برای مثال، تامین کننده 10 درصد از RDI (میزان دریافت مرجع) مورد نیاز بدن به ویتامین آ، 25 درصد از RDI از ویتامین د، 30 درصد از RDI از کلسیم و 8 گرم چربی است. همچنین دارای مقادیر مختلف کلسیم، فسفر، آهن، منیزیم، منگنز، پتاسیم و مس می‌باشد. در نتیجه، مصرف طولانی مدت کفیر به بهبود پوست و مو، سلامت قلب و عروق و ایمنی، درمان یبوست و از بین بردن میل شدید به مواد غذایی ناسالم مرتبط است. ";
            s.AboutKefirTitle = "درباره کفیر غنی از مواد مغذی";

            s.AbstractText = " توجه داشته باشید که مزایای کفیر که ذکر خواهد شد، محصول شیر حیوانات است. مشخصات تغذیه‌ای کفیر حاصل از شیر گیاهی (مانند شیر نارگیل) متفاوت است، هر چند در سلامت این محصول نیز شکی وجود ندارد. ";
            s.AbstractTitle = "مـزایـا کـفـیـر ";

            s.AwardCount = 3;
            s.ExpertText = " کارشناسان مجرب ما به شما کمک می کنند که زندگی سالم تری داشته باشید. ";
            s.ExpertTitle = "کـارشـنـاسـان مـا";

            s.GalleryText = " کفیر یک درمان طبیعی برای هر گونه آلرژی است، قوی‌ترین آنتی‌بیوتیک و مفید در درمان اگزما، بیماری کبد، ورم معده، سرطان روده بزرگ، سندرم روده تحریک‌پذیر، ورم مفاصل، کولیت، آسم، برونشیت، هپاتیت و سنگ کلیه است. ";
            s.GalleryTitle = "گـالـری تصاویر";

            s.NewsText = "در زمینه دوغ کفیر و محصولات مختلف با بروز شوید.";
            s.NewsTitle = "اخـبـار جدید دوغ کفیر";

            s.CupTitle = "یک فنجان";
            s.CupFirstTitle = "ویتامین آ";
            s.CupFirstPercent = 10;
            s.CupSecoundTitle = "ویتامین د";
            s.CupSecoundPercent = 25;
            s.CupThirdTitle = "ویتامین کلسیم";
            s.CupThirdPercent = 30;
            s.CupFourthTitle = "چربی";
            s.CupFourthPercent = 0.08F;

            context.Setting.AddOrUpdate(s);

        }
        context.SaveChanges();
    }
}
