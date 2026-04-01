document.addEventListener('DOMContentLoaded', () => {
    // Mobile menu toggle
    const menuBtn = document.querySelector('.mobile-menu-btn');
    const navMenu = document.querySelector('.nav-menu');

    if (menuBtn && navMenu) {
        const toggleMenu = () => {
            navMenu.classList.toggle('active');
            menuBtn.classList.toggle('active');
            const icon = menuBtn.querySelector('i');
            if (icon) {
                icon.classList.toggle('fa-bars');
                icon.classList.toggle('fa-times');
            }
        };

        menuBtn.addEventListener('click', toggleMenu);

        document.querySelectorAll('.nav-link').forEach(link => {
            link.addEventListener('click', () => {
                if (window.innerWidth <= 768) {
                    navMenu.classList.remove('active');
                    menuBtn.classList.remove('active');
                    const icon = menuBtn.querySelector('i');
                    if (icon) {
                        icon.classList.add('fa-bars');
                        icon.classList.remove('fa-times');
                    }
                }
            });
        });
    }

    // Navbar shadow on scroll
    const navbar = document.querySelector('.navbar');
    window.addEventListener('scroll', () => {
        if (!navbar) return;
        navbar.style.boxShadow = window.scrollY > 50
            ? '0 5px 20px rgba(0,0,0,0.15)'
            : '0 2px 15px rgba(0,0,0,0.08)';
    });

    // Hero slider
    const slides = document.querySelectorAll('.slide');
    const dots = document.querySelectorAll('.slider-dots .dot');
    const prevBtn = document.querySelector('.slider-btn.prev');
    const nextBtn = document.querySelector('.slider-btn.next');
    let currentSlide = 0;
    let slideInterval;

    const showSlide = (index) => {
        if (!slides.length) return;
        if (index >= slides.length) index = 0;
        if (index < 0) index = slides.length - 1;
        currentSlide = index;

        slides.forEach(slide => slide.classList.remove('active'));
        dots.forEach(dot => dot.classList.remove('active'));

        slides[currentSlide].classList.add('active');
        if (dots[currentSlide]) dots[currentSlide].classList.add('active');
    };

    const startAutoSlide = () => {
        if (!slides.length) return;
        clearInterval(slideInterval);
        slideInterval = setInterval(() => showSlide(currentSlide + 1), 5000);
    };

    const stopAutoSlide = () => clearInterval(slideInterval);

    if (nextBtn) {
        nextBtn.addEventListener('click', () => {
            stopAutoSlide();
            showSlide(currentSlide + 1);
            startAutoSlide();
        });
    }

    if (prevBtn) {
        prevBtn.addEventListener('click', () => {
            stopAutoSlide();
            showSlide(currentSlide - 1);
            startAutoSlide();
        });
    }

    dots.forEach((dot, index) => {
        dot.addEventListener('click', () => {
            stopAutoSlide();
            showSlide(index);
            startAutoSlide();
        });
    });

    if (slides.length) {
        showSlide(0);
        startAutoSlide();
    }

    document.addEventListener('keydown', (e) => {
        if (!slides.length) return;
        if (e.key === 'ArrowRight') {
            stopAutoSlide();
            showSlide(currentSlide + 1);
            startAutoSlide();
        } else if (e.key === 'ArrowLeft') {
            stopAutoSlide();
            showSlide(currentSlide - 1);
            startAutoSlide();
        }
    });

    // Event poster hover
    const eventItems = document.querySelectorAll('.event-item');
    const activePoster = document.getElementById('activePoster');
    if (eventItems.length && activePoster) {
        eventItems.forEach(item => {
            item.addEventListener('mouseenter', () => {
                eventItems.forEach(i => i.classList.remove('active'));
                item.classList.add('active');
                const posterUrl = item.getAttribute('data-poster');
                if (posterUrl) {
                    activePoster.style.opacity = '0';
                    setTimeout(() => {
                        activePoster.src = posterUrl;
                        activePoster.style.opacity = '1';
                    }, 200);
                }
            });
        });
    }

    // Courses carousel
    const coursesTrack = document.querySelector('.courses-carousel-track');
    const courseCards = document.querySelectorAll('.course-card-new');
    const coursePrevBtn = document.querySelector('.course-prev');
    const courseNextBtn = document.querySelector('.course-next');
    const courseDots = document.querySelectorAll('.course-dot');

    let currentCourseIndex = 0;
    const visibleCards = 4;
    const gap = 25;

    const updateCoursesCarousel = () => {
        if (!coursesTrack || !courseCards.length) return;
        const cardWidth = courseCards[0].offsetWidth;
        const maxIndex = Math.max(0, courseCards.length - visibleCards);
        currentCourseIndex = Math.min(currentCourseIndex, maxIndex);
        const offset = currentCourseIndex * (cardWidth + gap);
        coursesTrack.style.transform = `translateX(-${offset}px)`;
        courseDots.forEach((dot, index) => {
            dot.classList.toggle('active', index === currentCourseIndex);
        });
    };

    if (courseNextBtn) {
        courseNextBtn.addEventListener('click', () => {
            const maxIndex = Math.max(0, courseCards.length - visibleCards);
            currentCourseIndex = currentCourseIndex >= maxIndex ? 0 : currentCourseIndex + 1;
            updateCoursesCarousel();
        });
    }

    if (coursePrevBtn) {
        coursePrevBtn.addEventListener('click', () => {
            const maxIndex = Math.max(0, courseCards.length - visibleCards);
            currentCourseIndex = currentCourseIndex <= 0 ? maxIndex : currentCourseIndex - 1;
            updateCoursesCarousel();
        });
    }

    courseDots.forEach((dot, index) => {
        dot.addEventListener('click', () => {
            const maxIndex = Math.max(0, courseCards.length - visibleCards);
            currentCourseIndex = Math.min(index, maxIndex);
            updateCoursesCarousel();
        });
    });

    if (coursesTrack) {
        coursesTrack.addEventListener('mouseenter', () => {
            coursesTrack.style.animationPlayState = 'paused';
        });

        coursesTrack.addEventListener('mouseleave', () => {
            coursesTrack.style.animationPlayState = 'running';
        });
    }

    window.addEventListener('resize', updateCoursesCarousel);
    updateCoursesCarousel();
});

/* Mobil Dropdown Menu Icin Click Event'i (Sonradan eklenen iyilestirme) */
document.addEventListener('DOMContentLoaded', () => {
    if (window.innerWidth <= 991) {
        const dropdownLinks = document.querySelectorAll('.nav-item.dropdown > .nav-link');
        
        dropdownLinks.forEach(link => {
            link.addEventListener('click', (e) => {
                e.preventDefault();
                const parentItem = link.parentElement;
                
                // Diger acik olanlari kapat
                document.querySelectorAll('.nav-item.dropdown').forEach(item => {
                    if (item !== parentItem) {
                        item.classList.remove('mobile-active');
                    }
                });
                
                // Tiklanani ac/kapat
                parentItem.classList.toggle('mobile-active');
            });
        });
    }
});
