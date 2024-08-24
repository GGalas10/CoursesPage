function ChangeBtn(clickedBtn) {
    $(".ActiveBtn").addClass("InactiveBtn");
    $(".ActiveBtn").removeClass("ActiveBtn");
    clickedBtn.classList.add("ActiveBtn");
    clickedBtn.classList.remove("InactiveBtn");
    console.log(clickedBtn.dataset.value)
    if (clickedBtn.dataset.value == "Lesson") {
        $("#LessonSection").removeClass("hidden")
        $("#BaseSection").addClass("hidden")
    } else {
        $("#LessonSection").addClass("hidden")
        $("#BaseSection").removeClass("hidden")
    }
}
function SattlementsChangeBtn(clickedBtn) {
    var section = document.getElementById("DataSection");
    $(".ActiveBtn").addClass("InactiveBtn");
    $(".ActiveBtn").removeClass("ActiveBtn");
    clickedBtn.classList.add("ActiveBtn");
    clickedBtn.classList.remove("InactiveBtn");

    section.classList.remove("hidden");
    switch (clickedBtn.dataset.value) {
        case "Statistic":
            GetUserStatistic();
            break;
        case "Finances":
            section.innerHTML = financeModal;
            break;
        case "Raports":
            section.innerHTML = raportsModal;
            break;
        case "Invoices":
            section.innerHTML = invoicesModal;
            break;
    }
}
function GetUserStatistic() {
    var section = document.getElementById("DataSection");
    $.ajax({
        url: "/UserStatistic/GetUserSattlement",
        method: "GET",
        success: function (data) {
            section.innerHTML = statModal;
            section.innerHTML += StatData.replace("TUTAJCENA", data.howMuchEarned).replace("TUTAJILEKURSOW", data.howMuchSell);
        },
        error: function (xhr) {

        },
    });
}
function AddTopicSection(courseId) {
    document.getElementById("LessonAndTopicSection").classList.remove("hidden");
    document.getElementById("LessonAndTopicSection").innerHTML = `
    <h3>Dodawanie Tematu</h3>
    <label for="TopicName">Nazwa tematu</label>
    <input name="TopicName" id="TopicName" type="text"/>
    <label for="TopicDescription">Opis</label>
    <textarea id="TopicDescription" name="TopicDescription"></textarea>
    <p onclick="AddTopicToCourse('${courseId}')" class="PrimaryBtn ButtonFromP">Zapisz Temat</p>
    `;
}
function AddTopicToCourse(courseId) {
    var topicName = document.getElementById("TopicName").value;
    var topicDescription = document.getElementById("TopicDescription").value;
    if (topicName == "") {
        alert("Uzupełnij pole nazwy tematu");
        return;
    }
    if (topicDescription == "") {
        alert("Uzupełnij pole opisu tematu");
        return;
    }
    var formData = new FormData();
    formData.append('CourseId', courseId);
    formData.append("topicName", topicName);
    formData.append("topicDescription", topicDescription);
    $.ajax({
        url: "/AdminCourses/AddTopicToCourse",
        data: formData,
        method: "POST",
        contentType: false,
        processData: false,
        success: function () {
            location.reload();
        },
        error: function (xhr) {
            console.log(xhr);
        },
    });
}
const statModal = `<section class="text-center" style="width:100%"><h1>Statystyka</h1></section>`;
const financeModal = `<section class="text-center" style="width:100%"><h1>Finanse</h1></section>`;
const raportsModal = `<section class="text-center" style="width:100%"><h1>Raporty</h1></section>`;
const invoicesModal = `<section class="text-center" style="width:100%"><h1>Faktury</h1></section>`;

const StatData = `
<section class="d-flex justify-content-around">
<p>Od początku</p><p>Ostatnie 30 dni</p>
</section>
<section class="text-center">
    <p>Twoje wszystkie zarobki na kursach TUTAJCENA zł</p>
    <p>Łacznie sprzedałeś kursów TUTAJILEKURSOW</p>
</section>`;