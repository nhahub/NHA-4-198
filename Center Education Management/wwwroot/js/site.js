document.addEventListener("DOMContentLoaded", () => {
  const ownerForm = document.getElementById("form-owner");
  const studentForm = document.getElementById("form-student");

  document.querySelectorAll(".tab").forEach((tab) => {
    tab.addEventListener("click", () => {
      document.querySelectorAll(".tab").forEach((item) => item.classList.remove("active"));
      tab.classList.add("active");

      const isStudent = tab.dataset.tab === "student";
      if (ownerForm) ownerForm.style.display = isStudent ? "none" : "grid";
      if (studentForm) studentForm.style.display = isStudent ? "grid" : "none";
    });
  });

  document.querySelectorAll(".faq-item .faq-q").forEach((button) => {
    button.addEventListener("click", () => {
      button.closest(".faq-item")?.classList.toggle("open");
    });
  });
});
