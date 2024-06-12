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
                            <button class="PrimaryBtn">Przejdź</button>
                            </div>`
                    } else {

                    }
                });
            }
        },
        error(xhr) {
            console.log(xhr);
        },
    })
}