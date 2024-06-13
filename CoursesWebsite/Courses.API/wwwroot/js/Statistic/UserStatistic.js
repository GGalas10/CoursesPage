function GetUserNewestCourses() {
    const section = document.getElementById("SectionForCourses");
    $.ajax({
        url: "/UserStatistic/GetUserNewestCourses?HowMuch=3",
        method: "GET",
        success(data) {
            if (data.length <= 0) {
                section.innerHTML = "<p>Jeszcze nie ma żadnego kursu</p><p>Przejdź do zakładki <a href='/Creator/Courses'>Moje Kursy</a> aby dodać nowy kurs.</p>"
            } else {
                data.forEach((element) => {
                    if (element.picture == null) {
                        section.innerHTML +=
                            `<div class="GlassEfectSection OneCourse">
                            <h6>${element.name}</h6>
                            <img src="/Images/BrainHome.jpg" width=200px height=200px style="border-radius:25px"></img>
                            <button class="PrimaryBtn" onclick="GoToDetails('${element.id}')">Przejdź</button>
                            </div>`
                    } else {
                        section.innerHTML +=
                        `<div class="GlassEfectSection OneCourse">
                            <h6>${element.name}</h6>
                            <img src="${element.picture}" width=200px height=200px style="border-radius:25px"></img>
                            <button class="PrimaryBtn" onclick="GoToDetails('${element.id}')">Przejdź</button>
                            </div>`
                    }
                });
            }
        },
        error(xhr) {
            console.log(xhr);
        },
    })
}
function GoToDetails(Id) {
    location.href =`/AdminCourses/Details?CourseId=${Id}`;
}
function GetUserSattlements() {
    const section = document.getElementById("SattlementSection");
    $.ajax({
        url: "/UserStatistic/GetUserSattlement",
        method: "GET",
        success: function (data) {
            section.innerHTML = `
            <p>Na kursach zarobiłeś ${data.howMuchEarned} zł</p>
            <p>Łacznie sprzedałeś ${data.howMuchSell} kursów</p>
            <button class="PrimaryBtn" onclick="location.href = '/Creator/Settlements'">Przejdź do płatności</button>
            `
        },
        error: function (xhr) {
            console.log(xhr);
        }
    });
}