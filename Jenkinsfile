pipeline {
    agent { 
        docker 'microsoft/aspnetcore-build:2.0' 
    }
    stages {
        def app

        stage('build') {
            steps {
//                bat 'dotnet build' 
               sh 'dotnet build' 
            }
        }
        stage('test') {
            steps {
//                bat 'dotnet test one.test'
               sh 'dotnet test one.test'
            }
        }
        stage('containerize') {
            steps {
                /* This builds the actual image; synonymous to
                * docker build on the command line */

                app = docker.build("one")
            }
        }
    }
}