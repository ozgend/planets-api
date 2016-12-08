module.exports = function(grunt) {
    grunt.initConfig({
        exec: {
            build_source: {
                cmd: 'dotnet restore src/SolarSystem.Planets && dotnet build src/SolarSystem.Planets'
            },
            build_pack: {
                cmd: 'dotnet publish ./src/SolarSystem.Planets -c Release -o ./dist'
            }
        },
        clean: ['./dist/']
    });

    grunt.loadNpmTasks('grunt-exec');
    grunt.loadNpmTasks('grunt-contrib-clean');

    grunt.registerTask('default', ['clean', 'exec']);
};