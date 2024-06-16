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