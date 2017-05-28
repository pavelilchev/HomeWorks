var gulp = require('gulp');
var htmlmin = require('gulp-htmlmin');

gulp.task('minify', function() {
  return gulp.src('views/home/*.html')
    .pipe(htmlmin({collapseWhitespace: true}))
    .pipe(gulp.dest('views/home/min/'));
});