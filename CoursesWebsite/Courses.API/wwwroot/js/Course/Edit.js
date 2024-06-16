function ChangeBtn(clickedBtn) {
    $(".ActiveBtn").addClass("InactiveBtn");
    $(".ActiveBtn").removeClass("ActiveBtn");
    clickedBtn.classList.add("ActiveBtn");
    clickedBtn.classList.remove("InactiveBtn");
}