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
            agent any
            steps {
                script {
                    docker.image("one:${env.BUILD_NUMBER}").runWith('-p 80:80') { c ->
                        docker.image('microsoft/aspnetcore-build:2.0').inside("--link ${c.id}:app") {
                            sh 'dotnet test one.st'
                        }
                    } 
                }
            }
        }
    }
}