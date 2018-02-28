pipeline {
    agent none
    stages {
        stage('build') {
            agent { docker 'microsoft/aspnetcore-build:2.0' }
            steps {
               sh 'dotnet build' 
            }
        }
        stage('unit test') {
            agent { docker 'microsoft/aspnetcore-build:2.0' }
            steps {
               sh 'dotnet test one.ut'
            }
        }
        stage('containerize') {
            agent any
            steps {
                script {
                   docker.build("one:${env.BUILD_NUMBER}","one") 
                }
            }
        }
        stage('system test') {
            agent { docker "one:${env.BUILD_NUMBER}" }
            steps {
                sh 'dotnet test one.st'
            }
        }
    }
}