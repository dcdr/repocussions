pipeline {
    agent none
    stages {
        stage('build') {
            agent { docker 'microsoft/aspnetcore-build:2.0' }
            steps {
               sh 'dotnet build' 
            }
        }
        stage('test') {
            agent { docker 'microsoft/aspnetcore-build:2.0' }
            steps {
               sh 'dotnet test one.test'
            }
        }
        stage('containerize') {
            agent any
            steps {
                script {
                   def image = docker.build("one:${env.BUILD_NUMBER}","one") 
                }
            }
        }
    }
}